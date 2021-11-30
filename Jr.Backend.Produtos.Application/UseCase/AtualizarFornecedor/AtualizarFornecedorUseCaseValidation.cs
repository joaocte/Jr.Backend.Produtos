using Jr.Backend.Message.Events.Fornecedor.Events;
using Jror.Backend.Produtos.Infrastructure.Interfaces;
using MassTransit;
using System.Threading.Tasks;

namespace Jror.Backend.Produtos.Application.UseCase.AtualizarFornecedor
{
    public class AtualizarFornecedorUseCaseValidation : IAtualizarFornecedorUseCase
    {
        private readonly IAtualizarFornecedorUseCase cadastrarFornecedorUseCase;
        private readonly IFornecedorRepository fornecedorRepository;

        public AtualizarFornecedorUseCaseValidation(IAtualizarFornecedorUseCase cadastrarFornecedorUseCase, IFornecedorRepository fornecedorRepository)
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

        public async Task Consume(ConsumeContext<FornecedorAtualizadoEvent> context)
        {
            var @event = context.Message;

            var fornecedorJaCadastrado =
                    await fornecedorRepository.ExistsAsync(x => x.Cnpj == @event.Cnpj);

            if (!fornecedorJaCadastrado)
                return;

            await cadastrarFornecedorUseCase.Consume(context);
        }
    }
}