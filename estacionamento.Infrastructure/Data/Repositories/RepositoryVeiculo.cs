using estacionamento.Domain.Core.Interfaces.Repositories;
using estacionamento.Domain.Entitys;
using System;

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
    }
}