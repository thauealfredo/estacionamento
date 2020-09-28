using estacionamento.Domain.Core.Interfaces.Repositories;
using estacionamento.Domain.Entitys;

namespace estacionamento.Infrastructure.Data.Repositories
{
    public class RepositoryEstabelecimento : RepositoryBase<Estabelecimento>, IRepositoryEstabelecimento

    {
        private readonly SqlContext sqlContext;

        public RepositoryEstabelecimento(SqlContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}