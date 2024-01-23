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
            ValidateAudience = true, //Oluþturulan token deðerini hangi site için oluþturcaksýn?
            ValidateIssuer = true, //Oluþturulan token deðerini kim verdi
            ValidateLifetime = true, //Token süresi
            ValidateIssuerSigningKey = true, //Custom token deðeri

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

// Statik dosyalarýn servis edilmesi
var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

if (!Directory.Exists(uploadsPath))
{
    // Klasör yoksa oluþtur
    Directory.CreateDirectory(uploadsPath);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(uploadsPath),
    RequestPath = "/uploads"
});

// CORS konfigürasyonu
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

// Default dosya yolu olarak index.html veya baþka bir dosya belirtmek istiyorsanýz:
// app.UseDefaultFiles(); 

app.UseEndpoints(endpoints =>
{
    endpoints.MapFallbackToFile("/uploads/{**path}", "uploads/index.html");
    endpoints.MapControllers();
});

app.Run();
