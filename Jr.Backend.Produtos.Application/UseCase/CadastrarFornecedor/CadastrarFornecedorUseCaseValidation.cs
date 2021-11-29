using Jr.Backend.Message.Events.Fornecedor.Events;
using Jr.Backend.Produtos.Infrastructure.Interfaces;
using MassTransit;
using System.Threading.Tasks;

namespace Jr.Backend.Produtos.Application.UseCase.CadastrarFornecedor
{
    public class CadastrarFornecedorUseCaseValidation : ICadastrarFornecedorUseCase
    {
        private readonly ICadastrarFornecedorUseCase cadastrarFornecedorUseCase;
        private readonly IFornecedorRepository fornecedorRepository;

        public CadastrarFornecedorUseCaseValidation(ICadastrarFornecedorUseCase cadastrarFornecedorUseCase, IFornecedorRepository fornecedorRepository)
        {
            this.cadastrarFornecedorUseCase = cadastrarFornecedorUseCase;
            this.fornecedorRepository = fornecedorRepository;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                cadastrarFornecedorUseCase?.Dispose();
                fornecedorRepository?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public async Task Consume(ConsumeContext<FornecedorCadastradoEvent> context)
        {
            var @event = context.Message;

            var fornecedorJaCadastrado =
                    await fornecedorRepository.ExistsAsync(x => x.Cnpj == @event.Cnpj);

            if (fornecedorJaCadastrado)
                return;

            await cadastrarFornecedorUseCase.Consume(context);
        }
    }
}