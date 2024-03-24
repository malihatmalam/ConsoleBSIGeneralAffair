using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs
{
    public class AssetUserDTO
    {
        public int AssetUserId { get; set; }
        public int UserId { get; set; }
        public int AssetId { get; set; }
        public DateTime HandoverDateTime { get; set; }
        public string? HandoverFilePath { get; set; }
        public virtual AssetDTO Asset { get; set; } = null!;
        public virtual UserDTO User { get; set; } = null!;
    }
}
