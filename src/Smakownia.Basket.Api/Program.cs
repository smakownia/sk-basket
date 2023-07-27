using Smakownia.Api.Middlewares;
using Smakownia.Basket.Api.Services;
using Smakownia.Basket.Application.Providers;
using Smakownia.Basket.Application.Services;
using Smakownia.Basket.Domain.Repositories;
using Smakownia.Basket.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "Basket";
});
builder.Services.AddTransient<IBasketIdentityProvider, BasketIdentityProvider>();
builder.Services.AddTransient<IBasketsRepository, BasketsRepository>();
builder.Services.AddTransient<IBasketsService, BasketsService>();
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
