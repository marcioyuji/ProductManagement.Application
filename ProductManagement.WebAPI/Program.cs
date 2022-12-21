using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.DTOs;
using ProductManagement.Application.Interfaces;
using ProductManagement.Application.Services;
using ProductManagement.Core.Entities;
using ProductManagement.Core.Interfaces.Repositories;
using ProductManagement.Infrastructure.Configuration;
using ProductManagement.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opt.IncludeXmlComments(xmlPath);
});

//ConfigServices
builder.Services.AddDbContext<ContextBase>(options =>
                  options.UseSqlServer(
                      builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductService, ProductService>();

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<RequestSaveProductDTO, Product>();
    cfg.CreateMap<RequestUpdateProductDTO, Product>();
    cfg.CreateMap<RequestDeleteProductDTO, Product>();
    cfg.CreateMap<RequestGetAllProductDTO, Product>();

    cfg.CreateMap<RequestSaveCategoryDTO, Category>();
    cfg.CreateMap<RequestUpdateCategoryDTO, Category>();
    cfg.CreateMap<RequestDeleteCategoryDTO, Category>();
    cfg.CreateMap<RequestGetAllCategoryDTO, Category>();
});

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);


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
