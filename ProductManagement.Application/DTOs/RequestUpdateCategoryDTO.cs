using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.DTOs
{
    public class RequestUpdateCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Situation { get; set; }
    }
}
