using AutoMapper;
using Business.Abstracts;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ValidationException = Core.CrossCuttingConcerns.Exceptions.Types.ValidationException;


namespace Business.Features.Products.Commands.Create
{
    public class CreateProductCommand : IRequest
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }


        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
        {
            private readonly IProductRepository _productRepository;
            private readonly ICategoryService _categoryService;
            private readonly IMapper _mapper;


            public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ICategoryService categoryService)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _categoryService = categoryService;
            }

            public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                IValidator<CreateProductCommand> validator = new CreateProductCommandValidator();

                // validator.ValidateAndThrow(request); // kendi ex. fırlatacak.

                ValidationResult result = validator.Validate(request); // Validation'ı yapıcak. Sonucu vericek.

                if (!result.IsValid)
                {
                    throw new ValidationException(result.Errors.Select(i=>i.ErrorMessage).ToList());
                }

                Product? productWithSameName = await _productRepository.GetAsync(p => p.Name == request.Name);
                if (productWithSameName is not null)
                    throw new System.Exception("Aynı isimde 2. ürün eklenemez.");


                Category? category = await _categoryService.GetByIdAsync(request.CategoryId);
                if (category is null)
                    throw new BusinessException("Böyle bir kategori bulunamadı.");

                Product product = _mapper.Map<Product>(request);
                await _productRepository.AddAsync(product);
            }
        }
    }
}
