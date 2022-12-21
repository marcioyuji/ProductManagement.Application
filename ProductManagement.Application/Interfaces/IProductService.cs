using ProductManagement.Application.DTOs;
using ProductManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Interfaces
{
    public interface IProductService
    {
        Task<ResponseSaveProductDTO> Save(Product product);
        Task<ResponseUpdateProductDTO> Update(Product product);
        Task<ResponseDeleteProductDTO> Delete(Product product);
        Task<ResponseGetAllProductDTO> GetAllProduct(string ProductName);
    }
}
