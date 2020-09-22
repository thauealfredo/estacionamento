using estacionamento.Domain.Core.Interfaces.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace estacionamento.Infrastructure.Data.Repositorys
{
    public class RepositoryEstabelecimento<TEntity> : IRepositoryEstabelecimento<TEntity> where TEntity : class
    {
        private readonly SqlContext sql;

        public RepositoryEstabelecimento(SqlContext sql)
        {
            this.sql = sql;
        }

        public void Add(TEntity obj)
        {
            try
            {
                sql.Set<TEntity>().Add(obj);
                sql.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return sql.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return sql.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            try
            {
                sql.Set<TEntity>().Remove(obj);
                sql.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TEntity obj)
        {
            try
            {
                sql.Set<TEntity>().Update(obj);
                sql.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}