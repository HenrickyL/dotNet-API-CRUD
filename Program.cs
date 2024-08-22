using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;
using StudentApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionando o contexto do Entity Framework para o Student
//builder.Services.AddDbContext<Context>(options =>
//    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

builder.Services.AddDbContext<Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

// Adicionando o contexto do MongoDB
builder.Services.AddSingleton<MongoDbContext>();

// Registrando o UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Registra serviços de domínioaaaaaaaa
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<CohortService>();         

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Context>();
builder.Services.AddSingleton<MongoDbContext>();


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
