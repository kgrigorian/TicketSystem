using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClientLib.Models;

namespace ClientLib.Services
{
    public class ProductService: BaseService
    {
        public ProductService():base(ServiceConstatns.ServiceUrlPath["productsUrlPath"])
        {

        }

        public async Task<List<Models.Product>> GetAllProducts()
        {

            return await base.GetData<List<Models.Product>>("");
        }

        public async Task<Models.Product> GetProductById(int id)
        {
            return await base.GetData<Models.Product>(id.ToString());
        }

        public async Task<Product> DeleteProduct(int id)
        {
            return await base.DeleteData<Product>(id.ToString());
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            return await base.PutData<Product>(product);
        }

        public async Task<Product> AddProduct(Product product)
        {
            return await base.PostData<Product>(product);
        }
    }
}
