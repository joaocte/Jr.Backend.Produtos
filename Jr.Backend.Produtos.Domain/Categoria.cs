using System;
using System.Text.Json.Serialization;

namespace Jr.Backend.Produtos.Domain
{
    public class Categoria
    {
        [JsonConstructor]
        public Categoria(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
        }

        public Categoria(Guid id, string nome) : this(nome)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
    }
}