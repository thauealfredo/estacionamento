using estacionamento.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace estacionamento.Infrastructure.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SqlContext(
                serviceProvider.GetRequiredService<DbContextOptions<SqlContext>>()))
            {
                if (context.Estabelecimentos.Any())
                {
                    return;
                }

                if (context.Veiculos.Any())
                {
                    return;
                }

                context.Estabelecimentos.AddRange(
                    new Estabelecimento
                    {
                        Id = 1,
                        Nome = "EstacioneAq",
                        CNPJ = 12345678910111,
                        Endereco = "R. Alameda santos, 514 ",
                        Telefone = 1334642658,
                        VagaCarro = 80,
                        VagaMoto = 30
                    },
                    new Estabelecimento
                    {
                        Id = 2,
                        Nome = "EstacioneAqExtension",
                        CNPJ = 23456789101122,
                        Endereco = "R. Alameda santos, 585 ",
                        Telefone = 1334642658,
                        VagaCarro = 50,
                        VagaMoto = 40
                    });



                context.Veiculos.AddRange(
                    new Veiculo
                    {
                        Id = 1,
                        Placa = "abc-2586",
                        Marca = "audi",
                        Modelo = "a5",
                        Tipo = 1,
                        IdVaga = 38,
                        IdEstabelecimento = 1,
                        HrEntrada = DateTime.Now,
                        HrSaida= DateTime.MinValue
                    },
                    new Veiculo
                    {
                        Id = 2,
                        Placa = "zxv-4486",
                        Marca = "yamaha",
                        Modelo = "xj6",
                        Tipo = 2,
                        IdVaga = 25,
                        IdEstabelecimento = 1,
                        HrEntrada = DateTime.Now,
                        HrSaida = DateTime.MinValue
                    },

                     new Veiculo
                     {
                         Id = 3,
                         Placa = "dhj-2696",
                         Marca = "hyundai",
                         Modelo = "tucson",
                         Tipo = 1,
                         IdVaga = 78,
                         IdEstabelecimento = 2,
                         HrEntrada = DateTime.Now,
                         HrSaida = DateTime.MinValue
                     },
                    new Veiculo
                    {
                        Id = 4,
                        Placa = "vys-1186",
                        Marca = "honda",
                        Modelo = "hornet",
                        Tipo = 2,
                        IdVaga = 34,
                        IdEstabelecimento = 2,
                        HrEntrada = DateTime.Now,
                        HrSaida = DateTime.MinValue
                    }

                   );


                context.SaveChanges();
            }
        }
    }
}