using AutoMapper;
using Jr.Backend.Message.Events.Fornecedor.Events;
using Jror.Backend.Libs.Infrastructure.Data.Shared.Interfaces;
using Jror.Backend.Produtos.Infrastructure.Entity;
using Jror.Backend.Produtos.Infrastructure.Interfaces;
using MassTransit;
using System.Threading.Tasks;

namespace Jror.Backend.Produtos.Application.UseCase.CadastrarFornecedor
{
    public class CadastrarFornecedorUseCase : ICadastrarFornecedorUseCase
    {
        private readonly IFornecedorRepository fornecedorRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IBus bus;

        public CadastrarFornecedorUseCase(IFornecedorRepository fornecedorRepository, IMapper mapper, IBus bus, IUnitOfWork unitOfWork)
        {
            this.fornecedorRepository = fornecedorRepository;
            this.mapper = mapper;
            this.bus = bus;
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

        public async Task Consume(ConsumeContext<FornecedorCadastradoEvent> context)
        {
            var @event = context.Message;
            var entityFornecedor = mapper.Map<Fornecedor>(@event);

            var taskInsert = fornecedorRepository.AddAsync(entityFornecedor);
            var taskCommit = unitOfWork.CommitAsync();

            await Task.WhenAll(taskInsert, taskCommit);
        }
    }
}