using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Departement
{
    public class DepartementUpdateDTO
    {
        [Required(ErrorMessage = "ID departement harus diisi")]
        [Range(0, 1000, ErrorMessage = "departement Belum dipilih")]
        public int DepartementID { get; set; }

        [Required(ErrorMessage = "Nama department harus diisi")]
        [StringLength(100, ErrorMessage = "Maksimal 100 karakter dan minimal 2 karakter",
            MinimumLength = 2)]
        public string DepartementName { get; set; }
    }
}
