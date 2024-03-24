﻿using BSIGeneralAffair.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.Data.Interfaces
{
    public interface IDepartmentData
    {
        Task<IEnumerable<Departement>> GetAll();
        Task<IEnumerable<Departement>> GetByName(String name);
        Task<int> GetCount(string name);
    }
}
