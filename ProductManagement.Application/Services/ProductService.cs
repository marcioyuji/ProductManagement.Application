using ProductManagement.Core.Entities;
using ProductManagement.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Application.Interfaces;
using ProductManagement.Application.DTOs;

namespace ProductManagement.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<ResponseSaveProductDTO> Save(Product product)
        {
            ResponseSaveProductDTO responseSaveProductDTO = new ResponseSaveProductDTO();
            try
            {
                Category category = await _categoryRepository.GetEntityById(product.CategoryId);

                if (category == null || !category.Situation)
                    throw new Exception("Categoria não cadastrada");

                await _productRepository.Save(product);
                responseSaveProductDTO.Success = true;
                responseSaveProductDTO.StatusCode = System.Net.HttpStatusCode.Created;
                responseSaveProductDTO.Message = "Produto salvo com sucesso";
            }
            catch (Exception ex)
            {
                responseSaveProductDTO.Success = false;
                responseSaveProductDTO.StatusCode = System.Net.HttpStatusCode.BadRequest;
                responseSaveProductDTO.Message = ex.Message;
            }
            return responseSaveProductDTO;
        }

        public async Task<ResponseUpdateProductDTO> Update(Product product)
        {
            ResponseUpdateProductDTO responseUpdateProductDTO = new ResponseUpdateProductDTO();
            try
            {
                Category category = await _categoryRepository.GetEntityById(product.CategoryId);

                if (category == null || !category.Situation)
                    throw new Exception("Categoria não cadastrada");

                await _productRepository.Update(product);
                responseUpdateProductDTO.Success = true;
                responseUpdateProductDTO.StatusCode = System.Net.HttpStatusCode.OK;
                responseUpdateProductDTO.Message = "Produto atualizado com sucesso";
            }
            catch (Exception ex)
            {
                responseUpdateProductDTO.Success = false;
                responseUpdateProductDTO.StatusCode = System.Net.HttpStatusCode.BadRequest;
                responseUpdateProductDTO.Message = ex.Message;
            }
            return responseUpdateProductDTO;
        }

        public async Task<ResponseDeleteProductDTO> Delete(Product product)
        {
            ResponseDeleteProductDTO responseDeleteProductDTO = new ResponseDeleteProductDTO();
            try
            {
                product = await _productRepository.GetEntityById(product.Id);
                await _productRepository.DeleteProduct(product);
                responseDeleteProductDTO.Success = true;
                responseDeleteProductDTO.StatusCode = System.Net.HttpStatusCode.OK;
                responseDeleteProductDTO.Message = "Produto desativado com sucesso";
            }
            catch (Exception ex)
            {
                responseDeleteProductDTO.Success = false;
                responseDeleteProductDTO.StatusCode = System.Net.HttpStatusCode.BadRequest;
                responseDeleteProductDTO.Message = ex.Message;
            }
            return responseDeleteProductDTO;
        }

        public async Task<ResponseDeleteProductDTO> GetEntityById(int Id)
        {
            await _productRepository.GetEntityById(Id);
            return new ResponseDeleteProductDTO();
        }

        public async Task<ResponseGetAllProductDTO> GetAllProduct(string ProductName)
        {
            ResponseGetAllProductDTO responseGetAllProductDTO = new ResponseGetAllProductDTO();
            try
            {
                responseGetAllProductDTO.Products = await _productRepository.GetAllProduct(ProductName);
                responseGetAllProductDTO.Success = true;
                responseGetAllProductDTO.StatusCode = System.Net.HttpStatusCode.OK;
                responseGetAllProductDTO.Message = "Produto encontrada com sucesso";
            }
            catch (Exception ex)
            {
                responseGetAllProductDTO.Success = false;
                responseGetAllProductDTO.StatusCode = System.Net.HttpStatusCode.NotFound;
                responseGetAllProductDTO.Message = ex.Message;
            }
            return responseGetAllProductDTO;
        }
    }
}
