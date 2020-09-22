﻿using System.Collections.Generic;

namespace estacionamento.Domain.Core.Interfaces.Services
{
    public interface IServiceEstabelecimento<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);
    }
}