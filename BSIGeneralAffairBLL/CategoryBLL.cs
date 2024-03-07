using BSIGeneralAffairBLL.DTO.Category;
using BSIGeneralAffairBLL.Interfaces;
using BSIGeneralAffairBO_C;
using BSIGeneralAffairDAL_C;
using BSIGeneralAffairDAL_C.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL
{
    public class CategoryBLL : ICategoryBLL
    {
        private readonly ICategoryDAL _categoryDAL;
        public CategoryBLL() {
            _categoryDAL = new DALCategory();
        }
        public void Delete(int categorytID)
        {
            if (categorytID <= 0)
            {
                throw new ArgumentException("Category ID is required");
            }

            try
            {
                _categoryDAL.Delete(categorytID);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            List<CategoryDTO> listCategoriesDTO = new List<CategoryDTO>();
            var categories = _categoryDAL.GetAll();
            foreach (var category in categories)
            {
                listCategoriesDTO.Add(new CategoryDTO
                {
                    AssetCategoryID = (int)category.AssetCategoryID,
                    AssetCategoryName = category.AssetCategoryName,
                    UpdatedAt = category.UpdatedAt
                });
            }
            return listCategoriesDTO;
        }

        public CategoryDTO GetByCategoryID(int categoryID)
        {
            CategoryDTO categoryDTO = new CategoryDTO();
            var category = _categoryDAL.GetById(categoryID);
            if (category != null)
            {
                categoryDTO.AssetCategoryName = category.AssetCategoryName;
                categoryDTO.UpdatedAt = category.UpdatedAt;
            }
            else
            {
                throw new ArgumentException($"Category {categoryID} not found");
            }
            return categoryDTO;
        }

        public IEnumerable<CategoryDTO> GetByName(string name)
        {
            var categories = _categoryDAL.GetByNamesCategory(name);

            List<CategoryDTO> listCategoryDTOs = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                listCategoryDTOs.Add(new CategoryDTO
                {
                    AssetCategoryID = (int)category.AssetCategoryID,
                    AssetCategoryName = category.AssetCategoryName,
                    UpdatedAt = category.UpdatedAt
                });
            }
            return listCategoryDTOs;
        }

        public int GetCountCategory(string name)
        {
            return _categoryDAL.GetCountCategory(name);
        }

        public IEnumerable<CategoryDTO> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            List<CategoryDTO> listCategoriesDTO = new List<CategoryDTO>();
            var categories = _categoryDAL.GetWithPagingCategory(pageNumber, pageSize, name);
            foreach (var category in categories)
            {
                listCategoriesDTO.Add(new CategoryDTO
                {
                    AssetCategoryID = (int)category.AssetCategoryID,
                    AssetCategoryName = category.AssetCategoryName,
                });

            }
            return listCategoriesDTO;
        }

        public void Insert(CategoryCreateDTO newCategory)
        {
            if (string.IsNullOrEmpty(newCategory.AssetCategoryName))
            {
                throw new ArgumentException("Category name is required");
            }
            else if (newCategory.AssetCategoryName.Length > 50)
            {
                throw new ArgumentException("Category name max length is 50");
            }

            try
            {
                var categoryDTO = new AssetCategory
                {
                    AssetCategoryName = newCategory.AssetCategoryName
                };
                _categoryDAL.Insert(categoryDTO);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Update(CategoryUpdateDTO updateCategory)
        {
            if (updateCategory.AssetCategoryID <= 0)
            {
                throw new ArgumentException("Category ID is required");
            }
            else if (string.IsNullOrEmpty(updateCategory.AssetCategoryName))
            {
                throw new ArgumentException("Category name is required");
            }
            else if (updateCategory.AssetCategoryName.Length > 50)
            {
                throw new ArgumentException("Category name max length is 50");
            }

            try
            {
                var category = new AssetCategory
                {
                    AssetCategoryID = (short?)updateCategory.AssetCategoryID,
                    AssetCategoryName = updateCategory.AssetCategoryName
                };
                _categoryDAL.Update(category);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
