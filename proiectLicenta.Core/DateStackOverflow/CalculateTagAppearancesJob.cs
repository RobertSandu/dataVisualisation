using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;

namespace proiectLicenta.DateStackOverflow
{
    public class CalculateTagAppearancesJob : BackgroundJob<int>, ITransientDependency
    {
        private readonly IRepository<TagGrouping> _tagGroupinRepository;
        private readonly IRepository<TagAppearance> _tagAppearancesRepository;

        public CalculateTagAppearancesJob(
            IRepository<TagGrouping> tagGroupingRepository,
            IRepository<TagAppearance> tagAppearancesRepository
            )
        {
            _tagGroupinRepository = tagGroupingRepository;
            _tagAppearancesRepository = tagAppearancesRepository;
        }
         
        [UnitOfWork]
        public override void Execute(int args)
        {
            if (! _tagAppearancesRepository.GetAll().Any())
            {
                //the dictionary that will hold the number of appearances betwen tags
                Dictionary<string, Dictionary<string, int>> tagAppearancesDictionary = new Dictionary<string, Dictionary<string, int>>();

                var tagGroupings = _tagGroupinRepository.GetAll().Where(x => x.Appearances > 100).ToList();

                foreach (TagGrouping currentTagGrouping in tagGroupings)
                {
                    string[] tags = Regex.Split(currentTagGrouping.Tags, "><");

                    for (int i = 0; i < tags.Length - 1; i++)
                    {
                        string trimmedTag = tags[i].TrimEnd('>').TrimStart('<');

                        if (!tagAppearancesDictionary.ContainsKey(trimmedTag))
                        {
                            tagAppearancesDictionary.Add(trimmedTag, new Dictionary<string, int>());
                        }

                        for (int j = i + 1; j < tags.Length; j++)
                        {
                            string correspondingTrimmedTag = tags[j].TrimEnd('>').TrimStart('<');

                            if (!tagAppearancesDictionary.ContainsKey(correspondingTrimmedTag))
                            {
                                tagAppearancesDictionary.Add(correspondingTrimmedTag, new Dictionary<string, int>());
                            }

                            if (tagAppearancesDictionary[trimmedTag].ContainsKey(correspondingTrimmedTag))
                            {
                                tagAppearancesDictionary[trimmedTag][correspondingTrimmedTag] =
                                    tagAppearancesDictionary[trimmedTag][correspondingTrimmedTag] +
                                    currentTagGrouping.Appearances;
                            }
                            else
                            {
                                tagAppearancesDictionary[trimmedTag].Add(correspondingTrimmedTag, currentTagGrouping.Appearances);
                            }

                            if (tagAppearancesDictionary[correspondingTrimmedTag].ContainsKey(trimmedTag))
                            {
                                tagAppearancesDictionary[correspondingTrimmedTag][trimmedTag] =
                                    tagAppearancesDictionary[correspondingTrimmedTag][trimmedTag] +
                                    currentTagGrouping.Appearances;
                            }
                            else
                            {
                                tagAppearancesDictionary[correspondingTrimmedTag].Add(trimmedTag, currentTagGrouping.Appearances);
                            }

                        }

                    }
                }

                //we save the tag appearances in the database

                foreach (var tagAppearancesDictionaryEntry in tagAppearancesDictionary)
                {
                    foreach (var pairEntry in tagAppearancesDictionaryEntry.Value)
                    {
                        var tagAppearance = new TagAppearance
                        {
                            Appearences = pairEntry.Value,
                            Tag1 = tagAppearancesDictionaryEntry.Key,
                            Tag2 = pairEntry.Key
                        };

                        _tagAppearancesRepository.Insert(tagAppearance);
                    }
                }
            }
        }
    }
}
