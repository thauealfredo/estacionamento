using estacionamento.Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace estacionamento.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<Estabelecimento> Estabelecimentos { get; set; }

        public DbSet<Veiculo> Veiculos { get; set; }
    }
}