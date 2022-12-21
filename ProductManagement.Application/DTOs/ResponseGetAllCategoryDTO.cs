using ProductManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.DTOs
{
    public class ResponseGetAllCategoryDTO : ResponseDTO
    {
        public List<Category> Categories { get; set; }
    }
}
