using FinanceControl.Application.Services;
using FinanceControl.Domain.Interfaces;
using FinanceControl.Infrastructure.Mongo.Repositories;
using FinanceControl.Infrastructure.Mongo.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Configure settings
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
var mongoSettings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();

// Mongo client & database
builder.Services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoSettings.ConnectionString));
builder.Services.AddSingleton(serviceProvider =>
{
    var client = serviceProvider.GetRequiredService<IMongoClient>();
    return client.GetDatabase(mongoSettings.DatabaseName);
});

// Repositories (Infrastructure implementations)
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IExpanseRepository, ExpanseRepository>();

// Application services
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ExpanseService>();

builder.Services.AddAutoMapper(typeof(FinanceControl.Application.Mapping.CategoryProfile));
builder.Services.AddAutoMapper(typeof(FinanceControl.Application.Mapping.ExpanseProfile));

// Add services to the container.

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
