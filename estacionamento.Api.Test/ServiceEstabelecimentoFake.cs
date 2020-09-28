using estacionamento.Domain.Core.Interfaces.Services;
using estacionamento.Domain.Entitys;
using System;
using System.Collections.Generic;

namespace estacionamento.Api.Test
{
    internal class ServiceEstabelecimentoFake<TEntity> : IServiceEstabelecimento<TEntity> where TEntity : class
    {
        private readonly List<Estabelecimento> estabelecimentos;
        public ServiceEstabelecimentoFake()
        {

        }

        public void Add(TEntity obj)
        {
 
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}