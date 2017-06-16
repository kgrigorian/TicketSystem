using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.DTOs;
using BAL.Factories;
using Domain;
using Interfaces;

namespace BAL.Services.ProductService
{
    public class ProductService : ServiceGeneric<ProductDTO, Product>, IProductService
    {
        public ProductService(IFactory<ProductDTO, Product> entityFactory, IRepository<Product> entityRepository) : base(entityFactory, entityRepository)
        {
        }
    }
}
