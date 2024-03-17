using BSIGeneralAffairBLL.DTO.Brand;

namespace MVCBSIGeneralAffairCosmetic.ViewModels
{
    public class ListBrandView
    {
        public BrandCreateDTO? BrandCreate {  get; set; }
        public IEnumerable<BrandDTO>? Brands { get; set; }
    }
}
