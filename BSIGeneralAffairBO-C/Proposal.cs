using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBO_C
{
    public class Proposal
    {
        public Proposal() { 
            this.Department = new Departement();
            this.User = new User();
            this.Employee = new Employee();
            this.Vendor = new Vendor();
            this.File = new List<ProposalFile>();
            this.ServiceHistory = new List<ProposalService>();
        }
        public string ProposalToken { get; set; }
        public byte? DepartementID { get; set; }
        public int? UserID { get; set; }
        public short? VendorID { get; set; }
        public string ProposalObjective { get; set; }
        public string ProposalDescription { get; set; }
        public DateTime? ProposalRequireDate { get; set; }
        public decimal? ProposalBudget { get; set; }
        public string ProposalNote { get; set; }
        public string ProposalType { get; set; }
        public string ProposalStatus { get; set; }
        public byte? ProposalApproveLevel { get; set; }
        public string ProposalNegotiationNote { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Departement Department { get; set; }
        public User User { get; set; }
        public Employee Employee { get; set; }
        public Vendor Vendor { get; set; }
        public List<ProposalFile> File { get; set; }
        public List<ProposalService> ServiceHistory { get; set; }
    }

}
