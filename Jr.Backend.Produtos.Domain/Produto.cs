using Jr.Backend.Libs.Domain.Abstractions;
using System;

namespace Jr.Backend.Produtos.Domain
{
    public class Produto : Entity
    {
        public string NomeProduto { get; private set; }
        public long Quantidade { get; private set; }
        public long QuantidadeMinimaEstoque { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public Guid FornecedorId { get; private set; }
        public string Descricao { get; private set; }
        public long LimiteMaximoPorPedido { get; private set; }
    }
}