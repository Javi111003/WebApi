global using FastEndpoints;
global using FluentValidation;
global using FastEndpoints.Swagger;
global using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();

var app = builder.Build();
app.UseFastEndpoints();
app.UseSwaggerGen();
app.Run();
