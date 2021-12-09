using Jr.Backend.Libs.Domain.Abstractions;
using Jr.Backend.Produtos.Domain.ValueObjects;
using Jr.Backend.Produtos.Domain.ValueObjects.Enuns;
using System;

namespace Jr.Backend.Produtos.Domain
{
    public class Produto : Entity
    {
        public string Descricao { get; private set; }
        public TipoItem TipoItem { get; private set; }
        public Unidade Unidade { get; private set; }
        public Categoria Categoria { get; private set; }
        public Preco Preco { get; private set; }
        public Guid FornecedorId { get; }
    }
}