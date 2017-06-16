using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAL.DTOs;
using BAL.Services.ProductService;
using Domain;

namespace WebApp.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_productService.All());
        }

        public IHttpActionResult Get(int id)
        {
            var product = _productService.GetById(id);
            if (null == product)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] ProductDTO product)
        {
            var productAdded = _productService.Add(product);
            return CreatedAtRoute("DefaultApi", new { id = product.ProductId }, productAdded);
        }
        [HttpDelete]
        public IHttpActionResult DeleteEntity(int id)
        {
            var product = _productService.GetById(id);
            if (null == product)
            {
                return NotFound();
            }
            product = _productService.Delete(id);
            return Ok(product);
        }

        [HttpPut]
        public IHttpActionResult UpdateEntity([FromBody] ProductDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _productService.Update(product);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
