using BLL;
using BLL_EF;
using DataAccesLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SklepContext>();
builder.Services.AddScoped<OrderInt, OrderImpl>();
builder.Services.AddScoped<ProductInt, ProdImpl>();
builder.Services.AddScoped<BasketInt, BasketImpl>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Sklep", builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .Build();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("Sklep");
app.UseAuthorization();

app.MapControllers();

app.Run();
