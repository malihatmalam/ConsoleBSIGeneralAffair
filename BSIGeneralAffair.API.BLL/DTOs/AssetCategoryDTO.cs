using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs
{
    public class AssetCategoryDTO
    {
        public short AssetCategoryId { get; set; }
        public string AssetCategoryName { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<AssetDTO> Assets { get; set; } = new List<AssetDTO>();
    }
}
