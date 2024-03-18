using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Asset
{
    public class AssetUpdateDTO
    {
        [Required(ErrorMessage = "Kode asset harus diisi")]
        public string AssetNumber { get; set; }
        [Required(ErrorMessage = "Brand harus diisi")]
        public int? Brand { get; set; }
        [Required(ErrorMessage = "Kategori harus diisi")]
        public int? AssetCategoryID { get; set; }
        public string AssetFactoryNumber { get; set; }
        [Required(ErrorMessage = "Nama asset harus diisi")]
        public string AsssetName { get; set; }
        [Required(ErrorMessage = "Biaya harus diisi")]
        public decimal? AssetCost { get; set; }
        [Required(ErrorMessage = "Tanggal pengadaan harus diisi")]
        public string AssetProcurementDate { get; set; }
        public bool? AssetFlagActive { get; set; }
        [Required(ErrorMessage = "Kondisi asset harus diisi")]
        public string AssetCondition { get; set; }
    }
}
