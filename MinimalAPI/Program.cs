using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinimalAPI;
using MinimalAPI.Model;

var builder = WebApplication.CreateBuilder(args);

//Injeção de dependencia
builder.Services.AddDbContext<PessoaDbContext>(options => options.UseInMemoryDatabase("Pessoas"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimal API v1");
});


app.MapGet("/pessoas", async (PessoaDbContext dbContext) => await dbContext.Pessoas.ToListAsync());

app.MapGet("/pessoas/{id}", async (int id, PessoaDbContext dbContext) => await dbContext.Pessoas.FirstOrDefaultAsync(a => a.Id == id));

app.MapPost("/pessoas", async (Pessoa pessoa, PessoaDbContext dbContext) =>
{
    dbContext.Pessoas.Add(pessoa);
    await dbContext.SaveChangesAsync();

    return pessoa;
});

app.MapPut("/pessoas/{id}", async (int id, Pessoa pessoa, PessoaDbContext dbContext) =>
{
    dbContext.Entry(pessoa).State = EntityState.Modified;
    await dbContext.SaveChangesAsync();
    return pessoa;
});

app.MapDelete("/pessoas/{id}", async (int id, PessoaDbContext dbContext) =>
{
    var pessoa = await dbContext.Pessoas.FirstOrDefaultAsync(a => a.Id == id);

    dbContext.Pessoas.Remove(pessoa);
    await dbContext.SaveChangesAsync();
    return;
});


app.Run();
