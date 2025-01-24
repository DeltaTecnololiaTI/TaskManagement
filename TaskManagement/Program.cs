using TaskManagement.Infra.Context;
using TaskManagement.Infra.Interfaces;
using TaskManagement.Infra.Repositories;

using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Services;
using TaskManagement.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Adicionar DatabaseContext e Repositório
builder.Services.AddSingleton<DatabaseContext>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// Configurar string de conexão
builder.Configuration.AddJsonFile("appsettings.json");

// Registrar AutoMapper
builder.Services.AddAutoMapper(typeof(TaskMappingProfile));

//Registrar S3Service
builder.Services.AddSingleton<S3Service>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITaskService, TaskService>();

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
