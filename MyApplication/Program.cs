using MyApplication.Entities;
using MyApplication.Services;

// OOP Concepts ->  Access Modifiers, Constructor, Inheritance, Polymorphism
// Interface, Abstraction

Product product = new();
product.Name = "Monitör";
product.UnitPrice = 50;
product.Id = 1;

BaseProductService productService = new ProductService();
productService.AddProductWithLogging(product);

BaseProductService productService2 = new ProductServiceMySql();
productService2.AddProductWithLogging(product);

// Sen bir product servis olacaksan => şunu şunu yapacaksın.