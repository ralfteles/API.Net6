using Microsoft.EntityFrameworkCore;
using MinimalAPI.Model;

namespace MinimalAPI
{
    public class PessoaDbContext : DbContext
    {
        public PessoaDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
