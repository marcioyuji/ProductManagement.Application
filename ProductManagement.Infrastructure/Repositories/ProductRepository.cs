using Microsoft.EntityFrameworkCore;
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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public async Task DeleteProduct(Product product)
        {
            product.Situation = false;
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<Product>().Update(product);
                await data.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllProduct(string name)
        {
            List<Product> productList = new List<Product>();

            using (var data = new ContextBase(_OptionsBuilder))
            {
                if (name != "null")
                    productList =  data.Set<Product>().Where(x => x.Name.Equals(name) && x.Situation).Include(y => y.Category).ToList();
                else
                    productList = data.Set<Product>().Where(x => x.Situation).Include(y => y.Category).ToList();
            }
            return productList.Count > 0 ? productList : throw new Exception("Produto não encontrado");
        }
    }
}
