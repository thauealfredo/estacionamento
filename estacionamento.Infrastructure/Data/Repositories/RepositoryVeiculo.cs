using estacionamento.Domain.Core.Interfaces.Repositories;
using estacionamento.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace estacionamento.Infrastructure.Data.Repositories
{
    public class RepositoryVeiculo : RepositoryBase<Veiculo>, IRepositoryVeiculo
    {
        private readonly SqlContext sqlContext;

        public RepositoryVeiculo(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public new void Remove(Veiculo obj)
        {
            try
            {
                sqlContext.Set<Veiculo>().Update(obj);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Veiculo> GetByIdEstabelecimento(int id)
        {
            return sqlContext.Set<Veiculo>().ToList().Where(c=> c.IdEstabelecimento == id);
        }
    }
}