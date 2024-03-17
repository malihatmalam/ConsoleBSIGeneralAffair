using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Brand
{
    public class BrandCreateDTO
    {
        public int BrandId { get; set; }

        [Required(ErrorMessage = "Nama brand harus diisi")]
        [StringLength(100,ErrorMessage ="Nama brand maksimal 100 karakter", MinimumLength = 2)]
        public string BrandName { get; set;}
    }
}
