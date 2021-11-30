using Jr.Backend.Message.Events.Fornecedor.Events;
using MassTransit;
using System;

namespace Jror.Backend.Produtos.Application.UseCase.AtualizarFornecedor
{
    public interface IAtualizarFornecedorUseCase : IConsumer<FornecedorAtualizadoEvent>, IDisposable
    {
    }
}