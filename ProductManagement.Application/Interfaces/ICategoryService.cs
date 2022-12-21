using ProductManagement.Application.DTOs;
using ProductManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<ResponseSaveCategoryDTO> Save(Category category);
        Task<ResponseUpdateCategoryDTO> Update(Category category);
        Task<ResponseDeleteCategoryDTO> Delete(Category Objeto);
        Task<ResponseGetAllCategoryDTO> GetAllCategory(string categoryName);
    }
}
