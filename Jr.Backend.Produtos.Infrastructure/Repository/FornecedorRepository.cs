using Jr.Backend.Produtos.Infrastructure.Entity;
using Jr.Backend.Produtos.Infrastructure.Interfaces;
using Jror.Backend.Libs.Infrastructure.MongoDB.Abstractions.Interfaces;
using Jror.Backend.Libs.Infrastructure.MongoDB.Repository;

namespace Jr.Backend.Produtos.Infrastructure.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(IMongoContext context, string collectionName) : base(context, collectionName)
        {
        }
    }
}