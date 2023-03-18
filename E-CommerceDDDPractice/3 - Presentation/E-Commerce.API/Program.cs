using _0___SharedKernel.Domain.Repositories;
using _0___SharedKernel.Domain.UnitOfWork;
using _1___Domain.Authentication.Entities;
using _1___Domain.Orders.Events;
using _1___Domain.Orders.Services.EventHandlers;
using _2___Infrastructure;
using _2___Infrastructure.SharedKernel.Repositories;
using _2___Infrastructure.SharedKernel.UnitOfWork;
using E_Commerce.API.Categories.Services;
using E_Commerce.API.Infrastructure.AutoMapper;
using E_Commerce.API.Orders.Services;
using E_Commerce.API.Products.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductMapperService, ProductMapperService>();
builder.Services.AddScoped<ICategoryMapperService, CategoryMapperService>();
builder.Services.AddScoped<IOrderMapperService, OrderMapperService>();
builder.Services.AddScoped<INotificationHandler<OrderCreatedEvent>, OrderCreatedEventHandler>();
builder.Services.AddScoped<INotificationHandler<OrderUpdatedEvent>, OrderUpdatedEventHandler>();



// ConnectionString to map in Data Base
builder.Services.AddDbContext<ECommerceDbContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDb")));

builder.Services.AddIdentity<User, IdentityRole>
    (options => {
        //To enter any passowrd without restrictions
        options.Password.RequiredLength = 10;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.SignIn.RequireConfirmedAccount = true;

    }).AddEntityFrameworkStores<ECommerceDbContext>();

//Add AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

//Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
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
