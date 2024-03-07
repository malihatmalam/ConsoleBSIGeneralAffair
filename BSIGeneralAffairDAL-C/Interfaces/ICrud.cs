using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairDAL_C.Interfaces
{
    public interface ICrud<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
