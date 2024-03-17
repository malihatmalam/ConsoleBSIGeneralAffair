using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Globalization;
using System.Text;

namespace BSIGeneralAffairBLL.DTO.Employee
{
    public class EmployeeCreateDTO
    {
        [Required(ErrorMessage = "Nama depan harus diisi")]
        public string Firstname { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Nomor karyawan depan harus diisi")]
        [StringLength(100, ErrorMessage = "Maksimal 100 karakter dan minimal 2 karakter",
            MinimumLength = 2)]
        public string EmployeeNumber { get; set; }
        [Required(ErrorMessage = "Departement harus diisi")]
        public int DepartementID { get; set; }
        [Required(ErrorMessage = "Kantor harus diisi")]
        public int OfficeID { get; set; }
        [Required(ErrorMessage = "Jabatan karyawan harus diisi")]
        public string EmployeePositionLevel {  get; set; }
        [Required(ErrorMessage = "Posisi karyawan harus diisi")]
        public string EmployeeJobTitle { get; set; }
        [Required(ErrorMessage = "Jenis kelamin harus diisi")]
        public string EmployeeGender { get; set; }
        [Required(ErrorMessage = "Status pernikahan harus diisi")]
        public string EmployeeMaritalStatus { get; set; }
        public string EmployeeBirthDate { get; set; }
        [Required(ErrorMessage = "Tanggal diterima keja harus diisi")]
        public string EmployeeHireDate { get; set; }
        [Required(ErrorMessage = "Tipe karyawan harus diisi")]
        public string EmployeeType { get; set; }
        [Required(ErrorMessage = "Gaji harus diisi")]
        public decimal? EmployeeSalary { get; set; }
    }
}
