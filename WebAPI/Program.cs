using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Business;
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// DataAccess - Entity Framework

// Singleton-Scoped-Transient -> Lifetime
// Singleton => Üretilen baðýmlýlýk uygulama açýk olduðu sürece tek bir kere newlenir. 
// Her enjeksiyonda o instance kullanýlýr.

// Scoped => (API isteði) Ýstek baþýna 1 instance oluþturur.

// Transient => Her adýmda (her talepte) yeni 1 instance.
builder.Services.AddBusinessServices();
builder.Services.AddDataAccessServices();

// Assembly
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // JWT Konfigürasyonlarý..
        // TODO: Gerekli alanlarý appsettings.json'dan okuyarak burada token optionslarý belirle.
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
           // IssuerSigningKey = ""
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionMiddlewareExtensions();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
