using estacionamento.Domain.Core.Interfaces.Repositorys;
using estacionamento.Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace estacionamento.Domain.Services
{
    public class ServiceEstabelecimento<TEntity> : IServiceEstabelecimento<TEntity> where TEntity : class
    {
        private readonly IRepositoryEstabelecimento<TEntity> repository;

        public ServiceEstabelecimento(IRepositoryEstabelecimento<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Add(TEntity obj)
        {
            repository.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            repository.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            repository.Update(obj);
        }
    }
}