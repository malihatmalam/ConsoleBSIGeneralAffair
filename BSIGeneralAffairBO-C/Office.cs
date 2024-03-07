using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBO_C
{
    public class Office
    {
        public int OfficeID { get; set; }
        public string OfficeName { get; set; }
        public string OfficeAddress { get; set; }
        public bool? OfficeFlagActive { get; set; }
        public string UpdateAt { get; set; }
    }

}
