using System;
using System.Collections.Generic;
using System.Text;

namespace estacionamento.Domain.Core.Interfaces.Services
{
    public interface IServiceRelatorio<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> Relatorio();

        IEnumerable<TEntity> EntradaSaida(int id);

        void EntradaSaidaHora(int id);
    }
}
