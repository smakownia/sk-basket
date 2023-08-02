using Smakownia.Api.Middlewares;
using Smakownia.Basket.Api.Services;
using Smakownia.Basket.Application;
using Smakownia.Basket.Application.Clients;
using Smakownia.Basket.Application.Services;
using Smakownia.Basket.Domain.Repositories;
using Smakownia.Basket.Infrastructure.Clients;
using Smakownia.Basket.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IProductsClient, ProductsClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetConnectionString("Products")!);
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Smakownia.Basket.Application.AssemblyReference.Assembly));
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "Basket";
});
builder.Services.AddAutoMapper(typeof(BasketMapperProfile));
builder.Services.AddTransient<IBasketIdentityService, BasketIdentityService>();
builder.Services.AddTransient<IBasketsRepository, BasketsRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
