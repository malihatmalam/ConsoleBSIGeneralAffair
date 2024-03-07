using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBO_C
{
    public class AssetUser
    {
        public int? AssetUserID { get; set; }
        public int? UserID { get; set; }
        public int? AssetID { get; set; }
        public DateTime? HandoverDateTime { get; set; }
        public string HandoverFilePath { get; set; }
        public Asset Asset { get; set; }
        public User User { get; set; }
    }

}
