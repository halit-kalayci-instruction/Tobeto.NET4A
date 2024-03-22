using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    // api/products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string Hello([FromQuery]string name, [FromQuery] string surname)
        {
            var language = Request.Headers.AcceptLanguage;
            if (language == "en")
                return "Hello " + name + " " + surname;
            return "Merhaba " + name + " " + surname;
        }
        // Route Parameters, Query String => Get isteklerinde popüler
        // Body => POST,PUT
        // Headers => Yan bilgileri içerir. ()

        [HttpGet("{username}")]
        public string Tobeto([FromRoute]string username)
        {
            return "Tobeto Kullanıcı Adınız: " + username;
        }

        [HttpPost]
        public Product GoodBye([FromBody]Product product)
        {
            return product;
        }
    }
}
