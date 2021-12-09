using System;

namespace Jr.Backend.Produtos.Domain
{
    public class SubCategoria
    {
        public SubCategoria(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
        }

        public SubCategoria(Guid id, string nome) : this(nome)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
    }
}