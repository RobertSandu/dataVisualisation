using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using proiectLicenta.DateStackOverflow;

namespace proiectLicenta.ClasificariTIOBE
{
    public class ClasificareTIOBEManager : IClasificareTIOBEManager
    {

        public IEventBus EventBus { get; set; }

        private readonly IRepository<ClasificareTIOBE, Guid> _clasificareTioberRepository;

        

        public ClasificareTIOBEManager(
            IRepository<ClasificareTIOBE, Guid> clasificareTioberRepository
            ,IRepository<TagGrouping> tagGroupingRepository
            )
        {
            _clasificareTioberRepository = clasificareTioberRepository;
            EventBus = NullEventBus.Instance;

        }

        public async Task<List<ClasificareTIOBE>> GetAllAsync()
        {
            var @clasificareTIOBE = await _clasificareTioberRepository.GetAllListAsync();

            return @clasificareTIOBE;
        }

        public async Task<ClasificareTIOBE> GetAsync(Guid id)
        {
            var @clasificareTIOBE = await _clasificareTioberRepository.FirstOrDefaultAsync(id);

            if (@clasificareTIOBE == null)
            {
                throw new UserFriendlyException("Nu a putut gasi clasificare TIOBE ceruta");
            }

            return @clasificareTIOBE;

        }

        public IQueryable<ClasificareTIOBE> GetAll()
        {
            var @clasificareTIOBE =  _clasificareTioberRepository.GetAll();
            return @clasificareTIOBE;
        }
    }
}
