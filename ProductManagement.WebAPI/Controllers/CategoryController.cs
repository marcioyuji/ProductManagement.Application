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
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly ICategoryService _ICategoryService;
        public CategoryController(IMapper IMapper, ICategoryService ICategoryService)
        {
            _IMapper = IMapper;
            _ICategoryService = ICategoryService;
        }

        /// <summary>
        /// Cadastra uma Categoria.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseSaveCategoryDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ResponseSaveCategoryDTO> Save(RequestSaveCategoryDTO categoryDTO)
        {
            var category = _IMapper.Map<Category>(categoryDTO);
            return await _ICategoryService.Save(category);
        }

        /// <summary>
        /// Atualiza dados da Categoria.
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(ResponseUpdateCategoryDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ResponseUpdateCategoryDTO> Update(RequestUpdateCategoryDTO categoryDTO)
        {
            var category = _IMapper.Map<Category>(categoryDTO);
            return await _ICategoryService.Update(category);
        }

        /// <summary>
        /// Inativa uma Categoria.
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(typeof(ResponseDeleteCategoryDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ResponseDeleteCategoryDTO> Delete(RequestDeleteCategoryDTO categoryDTO)
        {
            var category = _IMapper.Map<Category>(categoryDTO);
            return await _ICategoryService.Delete(category);
        }

        /// <summary>
        /// Busca categoria por nome ou lista todos caso parametro null.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseGetAllCategoryDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ResponseGetAllCategoryDTO> GetAllCategory([FromQuery] RequestGetAllCategoryDTO categoryDTO)
        {
            var category = _IMapper.Map<Category>(categoryDTO);
            return await _ICategoryService.GetAllCategory(category.Name);
        }
    }
}
