using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectLicenta.DateGithub.Dtos
{
    public class GithubRepoDetails
    {

        public RootObject root { get; set; }

        public string link { get; set; }

        public string name { get; set; }
        
        public int count { get; set; }

    }
}
