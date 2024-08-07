using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Domains;
using ProductAPI.Interfaces;
using ProductAPI.Repositories;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productsRepository;

        public ProductController(IProductRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_productsRepository.GetProducts());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("id")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var product = _productsRepository.GetById(id);
                return Ok(product);
            }
           catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Products products)
        {
            try
            {
                _productsRepository.AddProduct(products);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
               _productsRepository.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
