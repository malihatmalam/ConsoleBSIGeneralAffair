using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Proposal
{
    public class ProposalUpdateDTO
    {
        [Required(ErrorMessage = "Token proposal harus diisi")]
        public string ProposalToken { get; set; }
        public int? VendorID { get; set; }
        [Required(ErrorMessage = "Tujuan proposal harus diisi")]
        public string ProposalObjective { get; set; }
        [Required(ErrorMessage = "Konten proposal harus diisi")]
        public string ProposalDescription { get; set; }
        [Required(ErrorMessage = "Tanggal dibutuhkan harus diisi")]
        [DataType(DataType.Date)]
        public string ProposalRequireDate { get; set; }
        [Required(ErrorMessage = "Budget dibutuhkan harus diisi")]
        public int ProposalBudget { get; set; }
        public string ProposalNote { get; set; }
        public string ProposalNegotiationNote { get; set; }
    }
}
