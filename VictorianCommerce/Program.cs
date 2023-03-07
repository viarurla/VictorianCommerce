using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VictorianCommerce.Data;
using VictorianCommerce.Interfaces;
using VictorianCommerce.Models;
using VictorianCommerce.Services;
using VictorianCommerce.Validators;
using VictorianCommerce.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Configuration Parsing
IConfigurationRoot config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.

// Data
builder.Services.AddDbContext<CommerceContext>(opts => opts.UseSqlServer(config.GetConnectionString("Default")));

// Mapper
var mapperCfg = new MapperConfiguration(cfg =>
{
    // Define the mapping from Purchase to PurchaseOutDto.
    cfg.CreateMap<Purchase, PurchaseOutDto>()
        .ForMember(dto => dto.Customer, opt => opt.MapFrom(src => src.Customer));
    cfg.CreateMap<PurchaseInDto, Purchase>()
        .ForMember(dto => dto.CustomerId, opt => opt.MapFrom(src => src.CustomerId));
    cfg.CreateMap<Customer, CustomerOutDto>()
        .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id));
});

// Then, create a new IMapper instance from the configuration.
var mapper = mapperCfg.CreateMapper();
builder.Services.AddSingleton(mapper);
// Access Services
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();

// Validators
builder.Services.AddTransient<IPurchaseValidator, PurchaseValidator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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