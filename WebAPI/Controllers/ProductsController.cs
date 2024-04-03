using Business.Abstracts;
using Business.Concretes;
using Business.Dtos.Product.Requests;
using Business.Dtos.Product.Responses;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<List<ListProductResponse>> GetAll()
        {
            return await _productService.GetAll();
        }

        [HttpPost]
        public async Task Add([FromBody] AddProductRequest product)
        {
            await _productService.Add(product);
        }

        [HttpGet("Senkron")]
        public string Sync()
        {
            Thread.Sleep(5000); // 5 saniye beklet.
            return "Sync endpoint";
        }

        [HttpGet("Asenkron")]
        public async Task<string> Async()
        {
            await Task.Delay(5000);
            return "Async endpoint";
        }
    }
}
// SOLID => S => SINGLE RESPONSIBILITY