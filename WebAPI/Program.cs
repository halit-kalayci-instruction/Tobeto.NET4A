using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Business;
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using TokenOptions = Core.Utilities.JWT.TokenOptions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Core.Utilities.Encryption;

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

TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
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
