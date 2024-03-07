using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBO_C
{
    public class Departement
    {
        public Departement()
        {
            //this.employees = new List<Employee>();
        }
        public int DepartementID { get; set; }
        public string DepartementName { get; set; }
        public string UpdatedAt { get; set; }
        //public List<Employee> employees { get; set; }
    }
}

