using Microsoft.EntityFrameworkCore;
using MinimalAPI;
using MinimalAPI.Configuration;
using MinimalAPI.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PessoaDbContext>(options => options.UseInMemoryDatabase("Pessoas"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

PessoaEndPointConfig.AddEndPoints(app);
SwaggerConfiguration.AddSwagger(app);

app.Run();
