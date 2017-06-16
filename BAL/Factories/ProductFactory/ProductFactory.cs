using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.DTOs;
using Domain;
using Domain.Enums;

namespace BAL.Factories
{
    public class ProductFactory : IProductFactory

    {
    public ProductDTO Create(Product product)
    {
        return new ProductDTO()
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            ProductCode = product.ProductCode,
            ProductCategory = product.ProductCategory
    };
    }
        public Product Create(ProductDTO dto)
        {
            return new Product()
            {
                ProductId = dto.ProductId,
                ProductName = dto.ProductName,
                ProductCode = dto.ProductCode,
                ProductCategory = dto.ProductCategory
            };
        }

    }
}
