using estacionamento.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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

        public DbSet<Veiculo> Veiuclos { get; set; }

        public override int SaveChanges()
        {
            //// quando for cadastrar na vaga
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("HrEntrada") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("HrEntrada").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("HrSaida").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}