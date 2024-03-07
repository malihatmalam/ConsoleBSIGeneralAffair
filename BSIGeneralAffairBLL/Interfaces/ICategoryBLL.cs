using BSIGeneralAffairBLL.DTO.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.Interfaces
{
    public interface ICategoryBLL
    {
        IEnumerable<CategoryDTO> GetAll();
        void Insert(CategoryCreateDTO newCategory);
        void Update(CategoryUpdateDTO updateCategory);
        void Delete(int categorytId);
        CategoryDTO GetByCategoryID(int categoryId);
        IEnumerable<CategoryDTO> GetByName(string name);
        IEnumerable<CategoryDTO> GetWithPaging(int pageNumber, int pageSize, string name);
        int GetCountCategory(string name);
    }
}
