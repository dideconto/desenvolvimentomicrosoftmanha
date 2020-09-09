using Microsoft.EntityFrameworkCore;

namespace BancoDados.Models
{
    class Context : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=(localdb)\mssqllocaldb;Database=PessoasDb;
                    Trusted_Connection=true");
        }
    }
}
