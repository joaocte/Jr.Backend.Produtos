using System.Text.Json.Serialization;

namespace Jr.Backend.Produtos.Infrastructure.Entity.Comum
{
    public class CnaesSecundario
    {
        [JsonConstructor]
        public CnaesSecundario(int codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        public int Codigo { get; private set; }

        public string Descricao { get; private set; }
    }
}