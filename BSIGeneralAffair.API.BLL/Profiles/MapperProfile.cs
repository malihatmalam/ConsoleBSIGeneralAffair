using AutoMapper;
using BSIGeneralAffair.API.BLL.DTOs;
using BSIGeneralAffair.API.Domain.Models;

namespace BSIGeneralAffair.API.BLL.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Approval, ApprovalDTO>().ReverseMap();
            CreateMap<ApprovalCreateDTO, Approval>();

            CreateMap<AssetCategory, AssetCategoryDTO>().ReverseMap();


            CreateMap<Asset, AssetDTO>().ReverseMap();


            CreateMap<AssetUser, AssetUserDTO>().ReverseMap();


            CreateMap<Brand, BrandDTO>().ReverseMap();


            CreateMap<Departement, DepartementDTO>().ReverseMap();


            CreateMap<Employee, EmployeeDTO>().ReverseMap();


            CreateMap<OfficeLocation, OfficeLocationDTO>().ReverseMap();


            CreateMap<Proposal, ProposalDTO>().ReverseMap();
            CreateMap<ProposalCreateDTO, Proposal>();
            CreateMap<ProposalUpdateDTO, Proposal>();

            CreateMap<ProposalFile, ProposalFileDTO>().ReverseMap();


            CreateMap<ProposalService, ProposalServiceDTO>().ReverseMap();


            CreateMap<User, UserDTO>().ReverseMap();


            CreateMap<Vendor, VendorDTO>().ReverseMap();
        }
    }
}
