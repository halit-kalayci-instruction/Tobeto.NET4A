using Business.Abstracts;
using Business.Concretes;
using Business.Features.Products.Commands.Create;
using Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task Add([FromBody] CreateProductCommand command)
        {
            await _mediator.Send(command);
        }

    }
}
// SOLID => S => SINGLE RESPONSIBILITY