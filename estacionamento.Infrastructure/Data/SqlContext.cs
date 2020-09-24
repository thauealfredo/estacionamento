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

        public DbSet<Veiculo> Veiculos { get; set; }

        public override int SaveChanges()
        {
            //// quando for cadastrar na vaga

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Id") != null))
            {
                if (entry.State == EntityState.Modified)
                {
                    if (entry.Property("Nome").CurrentValue == null)
                    {
                        entry.Property("Nome").IsModified = false;
                    }
                     if (entry.Property("CNPJ").EntityEntry == null)
                    {
                        entry.Property("CNPJ").IsModified = false;
                    }
                    if (entry.Property("Endereco").CurrentValue == null)
                    {
                        entry.Property("Endereco").IsModified = false;
                    }
                     if (entry.Property("Telefone").CurrentValue == null)
                    {
                        entry.Property("Telefone").IsModified = false;
                    }
                    if (entry.Property("VagaCarro").CurrentValue== null)
                    {
                        entry.Property("VagaCarro").IsModified = false;
                    }
                    if (entry.Property("VagaMoto").CurrentValue == null)
                    {
                        entry.Property("VagMoto").IsModified = false;
                    }

                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("HrEntrada") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("HrEntrada").CurrentValue = DateTime.Now;
                    entry.Property("HrSaida").CurrentValue = DateTime.MinValue;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("HrSaida").CurrentValue = DateTime.Now;
                    entry.Property("HrEntrada").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}