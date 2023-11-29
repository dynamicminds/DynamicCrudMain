using DynamicCrud.Api.Dto;
using DynamicCrud.Api.Interfaces;
using DynamicCrud.Api.Service;
using DynamicCrud.Dal.EF.CF;
using DynamicCrud.Entity.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServiceInfrastructure(builder.Configuration);
builder.Services.AddDataInfrastructure(builder.Configuration);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
