using Jror.Backend.Message.Events.Fornecedor.Events;
using MassTransit;
using System;

namespace Jr.Backend.Produtos.Application.UseCase.AtualizarFornecedor
{
    public interface IAtualizarFornecedorUseCase : IConsumer<FornecedorAtualizadoEvent>, IDisposable
    {
    }
}