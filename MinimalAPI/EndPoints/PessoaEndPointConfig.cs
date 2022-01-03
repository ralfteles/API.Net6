using Microsoft.EntityFrameworkCore;
using MinimalAPI.Model;

namespace MinimalAPI.EndPoints
{
    public class PessoaEndPointConfig
    {
        public static void AddEndPoints(WebApplication app)
        {
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
        }
    }
}
