using estacionamento.Domain.Core.Interfaces.Services;
using estacionamento.Domain.Entitys;
using System;
using System.Collections.Generic;

namespace estacionamento.Api.Test
{
    internal class ServiceEstabelecimentoFake<TEntity> : IServiceEstabelecimento 
        where TEntity : Estabelecimento
    {
        private readonly List<Estabelecimento> estabelecimentos;

        public ServiceEstabelecimentoFake()
        {
        }

        public void Add(TEntity obj)
        {
        }

        public void Add(Estabelecimento obj)
        {
            throw new NotImplementedException();
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

        public void Remove(Estabelecimento obj)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Estabelecimento obj)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Estabelecimento> IServiceBase<Estabelecimento>.GetAll()
        {
            throw new NotImplementedException();
        }

        Estabelecimento IServiceBase<Estabelecimento>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}