using ProductManagement.Core.Entities;
using ProductManagement.Core.Interfaces.Repositories;
using ProductManagement.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public async Task DeleteCategory(Category category)
        {
            category.Situation = false;
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<Category>().Update(category);
                await data.SaveChangesAsync();
            }
        }

        public async Task<List<Category>> GetAllCategory(string name)
        {
            List<Category> categoryList = new List<Category>();

            using (var data = new ContextBase(_OptionsBuilder))
            {
                if (name != "null")
                    categoryList = data.Set<Category>().Where(x => x.Name.Equals(name) && x.Situation).ToList();
                else
                    categoryList = data.Set<Category>().Where(x => x.Situation).ToList();
            }
            return categoryList.Count > 0 ? categoryList : throw new Exception("Categoria não encontrada");
        }

    }
}
