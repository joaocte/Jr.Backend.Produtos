using System;

namespace Jr.Backend.Produtos.Domain
{
    public class Unidade
    {
        public Unidade(string sigla, string nome)
        {
            Id = Guid.NewGuid();
            Sigla = sigla;
            Nome = nome;
        }

        public Unidade(Guid id, string sigla, string nome) : this(sigla, nome)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
        public string Sigla { get; private set; }
        public string Nome { get; private set; }
    }
}