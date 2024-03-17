using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Brand
{
    public class BrandUpdateDTO
    {
        [Required(ErrorMessage = "ID brand harus diisi")]
        [Range(0, 1000, ErrorMessage = "Brand Belum dipilih")]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Nama brand harus diisi")]
        [StringLength(100, ErrorMessage = "Nama brand maksimal 100 karakter", MinimumLength = 2)]
        public string BrandName { get; set;}
    }
}
