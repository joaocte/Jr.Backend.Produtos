using AutoMapper;
using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Repository;
using Jr.Backend.Message.Events.Fornecedor.Events;
using Jr.Backend.Produtos.Infrastructure.Entity;
using Jr.Backend.Produtos.Infrastructure.Interfaces;
using MassTransit;
using System.Threading.Tasks;

namespace Jr.Backend.Produtos.Application.UseCase.AtualizarFornecedor
{
    public class AtualizarFornecedorUseCase : IAtualizarFornecedorUseCase
    {
        private readonly IFornecedorRepository fornecedorRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public AtualizarFornecedorUseCase(IFornecedorRepository fornecedorRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.fornecedorRepository = fornecedorRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                fornecedorRepository?.Dispose();
                unitOfWork?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public async Task Consume(ConsumeContext<FornecedorAtualizadoEvent> context)
        {
            var @event = context.Message;
            var entityFornecedor = mapper.Map<Fornecedor>(@event);

            var oldFornecedor = await fornecedorRepository.GetAsync(x => x.Cnpj == @event.Cnpj);

            entityFornecedor.Id = oldFornecedor.Id;

            var taskInsert = fornecedorRepository.UpdateAsync(entityFornecedor);
            var taskCommit = unitOfWork.CommitAsync();

            await Task.WhenAll(taskInsert, taskCommit);
        }
    }
}