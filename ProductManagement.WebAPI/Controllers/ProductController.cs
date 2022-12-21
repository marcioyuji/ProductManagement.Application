using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.DTOs;
using ProductManagement.Application.Interfaces;
using ProductManagement.Core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IProductService _IProductService;
        public ProductController(IMapper IMapper, IProductService ProductService)
        {
            _IMapper = IMapper;
            _IProductService = ProductService;
        }

        /// <summary>
        /// Cadastra um Produto.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseSaveProductDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ResponseSaveProductDTO> Save(RequestSaveProductDTO productDTO)
        {
            var product = _IMapper.Map<Product>(productDTO);
            return await _IProductService.Save(product);
        }

        /// <summary>
        /// Atualiza dados do produto.
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(ResponseUpdateProductDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ResponseUpdateProductDTO> Update(RequestUpdateProductDTO productDTO)
        {
            var product = _IMapper.Map<Product>(productDTO);
            return await _IProductService.Update(product);
        }

        /// <summary>
        /// Inativa um produto.
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(typeof(ResponseDeleteProductDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ResponseDeleteProductDTO> Delete(RequestDeleteProductDTO productDTO)
        {
            var product = _IMapper.Map<Product>(productDTO);
            return await _IProductService.Delete(product);
        }

        /// <summary>
        /// Busca produto por nome ou lista todos caso parametro null.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseGetAllProductDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ResponseGetAllProductDTO> GetAllCategory([FromQuery]RequestGetAllProductDTO productDTO)
        {
            var product = _IMapper.Map<Product>(productDTO);
            return await _IProductService.GetAllProduct(product.Name);
        }
    }
}
