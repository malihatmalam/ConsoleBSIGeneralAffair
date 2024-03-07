using BSIGeneralAffairBLL.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Asset
{
    public class AssetUserDTO
    {
        public int? AssetUserID { get; set; }
        public int? UserID { get; set; }
        public int? AssetID { get; set; }
        public DateTime? HandoverDateTime { get; set; }
        public string HandoverFilePath { get; set; }
        public AssetDTO Asset { get; set; }
        public UserDTO User { get; set; }
    }
}
