using BoltCompany.Application;
using BoltCompany.Infrastructure;
using BoltCompany.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistenceServices()
    .AddInfrastructureServices();
builder.Services.AddApplicationServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin",options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true, //Olu�turulan token de�erini hangi site i�in olu�turcaks�n?
            ValidateIssuer = true, //Olu�turulan token de�erini kim verdi
            ValidateLifetime = true, //Token s�resi
            ValidateIssuerSigningKey = true, //Custom token de�eri

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))


        };
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Statik dosyalar�n servis edilmesi
var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

if (!Directory.Exists(uploadsPath))
{
    // Klas�r yoksa olu�tur
    Directory.CreateDirectory(uploadsPath);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(uploadsPath),
    RequestPath = "/uploads"
});

// CORS konfig�rasyonu
app.UseCors(x => x
    .SetIsOriginAllowed(origin => true)
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseRouting(); // UseRouting middleware'ini ekleyin.

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Default dosya yolu olarak index.html veya ba�ka bir dosya belirtmek istiyorsan�z:
// app.UseDefaultFiles(); 

app.UseEndpoints(endpoints =>
{
    endpoints.MapFallbackToFile("/uploads/{**path}", "uploads/index.html");
    endpoints.MapControllers();
});

app.Run();
