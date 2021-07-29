using System;
using System.Collections.Generic;

#nullable disable

namespace Webapi_Sys.Models
{
    public partial class TbResume
    {
        public int ResumeId { get; set; }
        public string UserName { get; set; }
        public int Sex { get; set; }
        public string Tel { get; set; }
        public int Age { get; set; }
        public string Education { get; set; }
    }
}
