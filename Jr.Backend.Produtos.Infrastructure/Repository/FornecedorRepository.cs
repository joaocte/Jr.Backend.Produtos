using Jror.Backend.Libs.Infrastructure.MongoDB.Abstractions.Interfaces;
using Jror.Backend.Libs.Infrastructure.MongoDB.Repository;
using Jror.Backend.Produtos.Infrastructure.Entity;
using Jror.Backend.Produtos.Infrastructure.Interfaces;

namespace Jror.Backend.Produtos.Infrastructure.Repository
{
    public class FornecedorRepository : MongoRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(IMongoContext context, string collectionName) : base(context, collectionName)
        {
        }
    }
}