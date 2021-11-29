using Jr.Backend.Libs.Infrastructure.MongoDB.Abstractions.Interfaces;
using Jr.Backend.Libs.Infrastructure.MongoDB.Repository;
using Jr.Backend.Produtos.Infrastructure.Entity;
using Jr.Backend.Produtos.Infrastructure.Interfaces;

namespace Jr.Backend.Produtos.Infrastructure.Repository
{
    public class FornecedorRepository : MongoRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(IMongoContext context, string collectionName) : base(context, collectionName)
        {
        }
    }
}