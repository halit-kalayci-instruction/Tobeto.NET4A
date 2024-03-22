using Business.Abstracts;
using Business.Concretes;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Singleton-Scoped-Transient -> Lifetime
// Singleton => Üretilen baðýmlýlýk uygulama açýk olduðu sürece tek bir kere newlenir. 
// Her enjeksiyonda o instance kullanýlýr.

// Scoped => (API isteði) Ýstek baþýna 1 instance oluþturur.

// Transient => Her adýmda (her talepte) yeni 1 instance.
builder.Services.AddSingleton<IProductService, ProductManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
