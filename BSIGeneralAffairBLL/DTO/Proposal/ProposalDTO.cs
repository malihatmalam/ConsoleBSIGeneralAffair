using BSIGeneralAffairBLL.DTO.Departement;
using BSIGeneralAffairBLL.DTO.Employee;
using BSIGeneralAffairBLL.DTO.User;
using BSIGeneralAffairBLL.DTO.Vendor;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Proposal
{
    public class ProposalDTO
    {
        public string ProposalToken { get; set; }
        public short? DepartementID { get; set; }
        public string DepartementName { get; set; }
        public int? UserID { get; set; }
        public string UserFullName { get; set; }
        public string EmployeePosition { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }
        public short? VendorID { get; set; }
        public string ProposalObjective { get; set; }
        public string ProposalDescription { get; set; }
        public string ProposalRequireDate { get; set; }
        public decimal? ProposalBudget { get; set; }
        public string ProposalNote { get; set; }
        public string ProposalType { get; set; }
        public string ProposalStatus { get; set; }
        public short? ProposalApproveLevel { get; set; }
        public string ProposalNegotiationNote { get; set; }
        //public List<ProposalService> ServiceHistory { get; set; }
    }
}
