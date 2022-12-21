using ProductManagement.Application.DTOs;
using ProductManagement.Application.Interfaces;
using ProductManagement.Core.Entities;
using ProductManagement.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
    
        public async Task<ResponseSaveCategoryDTO> Save(Category category)
        {
            ResponseSaveCategoryDTO responseSaveCategoryDTO = new ResponseSaveCategoryDTO();
            try
            {
                await _categoryRepository.Save(category);
                responseSaveCategoryDTO.Success = true;
                responseSaveCategoryDTO.StatusCode = System.Net.HttpStatusCode.Created;
                responseSaveCategoryDTO.Message = "Categoria salva com sucesso";
            }
            catch (Exception ex)    
            {
                responseSaveCategoryDTO.Success = false;
                responseSaveCategoryDTO.StatusCode = System.Net.HttpStatusCode.BadRequest;
                responseSaveCategoryDTO.Message = ex.Message;
            }
            return responseSaveCategoryDTO;
        }
        public async Task<ResponseUpdateCategoryDTO> Update(Category category)
        {
            ResponseUpdateCategoryDTO responseUpdateCategoryDTO = new ResponseUpdateCategoryDTO();
            try
            {
                await _categoryRepository.Update(category);
                responseUpdateCategoryDTO.Success = true;
                responseUpdateCategoryDTO.StatusCode = System.Net.HttpStatusCode.OK;
                responseUpdateCategoryDTO.Message = "Categoria atualizada com sucesso";
            }
            catch (Exception ex)
            {
                responseUpdateCategoryDTO.Success = false;
                responseUpdateCategoryDTO.StatusCode = System.Net.HttpStatusCode.BadRequest;
                responseUpdateCategoryDTO.Message = ex.Message;
            }
            return responseUpdateCategoryDTO;
        }
        public async Task<ResponseDeleteCategoryDTO> Delete(Category category)
        {
            ResponseDeleteCategoryDTO responseDeleteCategoryDTO = new ResponseDeleteCategoryDTO();
            try
            {
                category = await _categoryRepository.GetEntityById(category.Id);
                await _categoryRepository.DeleteCategory(category);
                responseDeleteCategoryDTO.Success = true;
                responseDeleteCategoryDTO.StatusCode = System.Net.HttpStatusCode.OK;
                responseDeleteCategoryDTO.Message = "Categoria desativada com sucesso";
            }
            catch (Exception ex)
            {
                responseDeleteCategoryDTO.Success = false;
                responseDeleteCategoryDTO.StatusCode = System.Net.HttpStatusCode.BadRequest;
                responseDeleteCategoryDTO.Message = ex.Message;
            }
            return responseDeleteCategoryDTO;
        }

        public async Task<ResponseDeleteCategoryDTO> GetCategoryById(int Id)
        {
            await _categoryRepository.GetEntityById(Id);
            return new ResponseDeleteCategoryDTO();
        }

        public async Task<ResponseGetAllCategoryDTO> GetAllCategory(string categoryName)
        {
            ResponseGetAllCategoryDTO responseGetAllCategoryDTO = new ResponseGetAllCategoryDTO();
            try
            {
                responseGetAllCategoryDTO.Categories = await _categoryRepository.GetAllCategory(categoryName);
                responseGetAllCategoryDTO.Success = true;
                responseGetAllCategoryDTO.StatusCode = System.Net.HttpStatusCode.OK;
                responseGetAllCategoryDTO.Message = "Categoria encontrada com sucesso";
            }
            catch(Exception ex)
            {
                responseGetAllCategoryDTO.Success = false;
                responseGetAllCategoryDTO.StatusCode = System.Net.HttpStatusCode.NotFound;
                responseGetAllCategoryDTO.Message = ex.Message;
            }
            return responseGetAllCategoryDTO;
        }
    }
}
