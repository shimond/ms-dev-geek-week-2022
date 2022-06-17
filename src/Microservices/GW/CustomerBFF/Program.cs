using Grpc.Core;
using Grpc.Net.Client.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpcClient<BasketAPI.Basket.BasketClient>(x =>
{
    x.Address = new Uri("http://basketapi");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/fromCatalog", async (BasketAPI.Basket.BasketClient basketClient) =>
{
    var res  = await basketClient.GetBasketByIdAsync(new BasketAPI.BasketRequest() {  Id = "dolor" });
    return Results.Ok(res);

});

app.Run();
