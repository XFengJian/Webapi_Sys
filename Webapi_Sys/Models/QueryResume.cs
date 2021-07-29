using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi_Sys.Models
{
    public class QueryResume
    {
        public string UserName { get; set; }
        public int Sex { get; set; }
        public string Tel { get; set; }
        public string Education { get; set; }
        public int Minage { get; set; }
        public int Maxage { get; set; }
    }
}
