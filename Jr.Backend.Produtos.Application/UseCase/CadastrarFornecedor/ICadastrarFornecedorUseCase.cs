using Jr.Backend.Message.Events.Fornecedor.Events;
using MassTransit;
using System;

namespace Jr.Backend.Produtos.Application.UseCase.CadastrarFornecedor
{
    public interface ICadastrarFornecedorUseCase : IConsumer<FornecedorCadastradoEvent>, IDisposable
    {
    }
}