using estacionamento.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            #region Estabelecimento

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Nome") != null))
            {
                if (entry.State == EntityState.Modified)
                {
                    if (entry.Property("Nome").CurrentValue == null)
                    {
                        entry.Property("Nome").IsModified = false;
                    }
                    if (((long)entry.Property("CNPJ").CurrentValue).Equals(0))
                    {
                        entry.Property("CNPJ").IsModified = false;
                    }
                    if (entry.Property("Endereco").CurrentValue == null)
                    {
                        entry.Property("Endereco").IsModified = false;
                    }
                    if (((int)entry.Property("Telefone").CurrentValue).Equals(0))
                    {
                        entry.Property("Telefone").IsModified = false;
                    }
                    if (((int)entry.Property("VagaCarro").CurrentValue).Equals(0))
                    {
                        entry.Property("VagaCarro").IsModified = false;
                    }
                    if (((int)entry.Property("VagaMoto").CurrentValue).Equals(0))
                    {
                        entry.Property("VagMoto").IsModified = false;
                    }
                }
            }

            #endregion Estabelecimento

            #region Veiculo

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("HrEntrada") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("HrEntrada").CurrentValue = DateTime.Now;

                    if (entry.Property("HrSaida").CurrentValue !=null)
                    {
                        entry.Property("HrSaida").IsModified = false;
                    }
                    else
                    {
                        entry.Property("HrSaida").CurrentValue = null;
                    }
                    
                }

                if (entry.State == EntityState.Modified)
                {
                    if ((DateTime)entry.Property("HrSaida").CurrentValue != null )
                        
                    {
                        entry.Property("HrSaida").CurrentValue = DateTime.Now.AddHours(1);
                    }
                    else
                    {
                        entry.Property("HrEntrada").IsModified = false;
                    }

                    if (entry.Property("Placa").CurrentValue == null)
                    {
                        entry.Property("Placa").IsModified = false;
                    }
                    if (entry.Property("Marca").CurrentValue == null)
                    {
                        entry.Property("Marca").IsModified = false;
                    }
                    if (entry.Property("Modelo").CurrentValue == null)
                    {
                        entry.Property("Modelo").IsModified = false;
                    }
                    if (((int)entry.Property("Tipo").CurrentValue).Equals(0))
                    {
                        entry.Property("Tipo").IsModified = false;
                    }
                    if (((int)entry.Property("IdVaga").CurrentValue).Equals(0))
                    {
                        entry.Property("IdVaga").IsModified = false;
                    }
                    if (((int)entry.Property("IdEstabelecimento").CurrentValue).Equals(0))
                    {
                        entry.Property("IdEstabelecimento").IsModified = false;
                    }
                }
            }

            #endregion Veiculo

            return base.SaveChanges();
        }
    }
}