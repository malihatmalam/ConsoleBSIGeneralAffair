using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs
{
    public class AssetDTO
    {
        public int AssetId { get; set; }
        public short BrandId { get; set; }
        public short AssetCategoryId { get; set; }
        public string? AssetFactoryNumber { get; set; }
        public string AssetNumber { get; set; } = null!;
        public string AsssetName { get; set; } = null!;
        public decimal? AssetCost { get; set; }

        public DateTime AssetProcurementDate { get; set; }

        public bool AssetFlagActive { get; set; }
        public string AssetCondition { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual AssetCategoryDTO AssetCategory { get; set; } = null!;
        public virtual ICollection<AssetUserDTO> AssetUsers { get; set; } = new List<AssetUserDTO>();
        public virtual BrandDTO Brand { get; set; } = null!;
        public virtual ICollection<ProposalServiceDTO> ProposalServices { get; set; } = new List<ProposalServiceDTO>();
    }
}
