using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Departement
{
    public class DepartementCreateDTO
    {
        [Required(ErrorMessage = "Nama departement harus diisi")]
        [StringLength(100, ErrorMessage = "Maksimal 100 karakter dan minimal 2 karakter", MinimumLength = 2)]
        public string DepartementName { get; set; }
    }
}
