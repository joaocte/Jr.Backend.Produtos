using Jror.Backend.Libs.Domain.Abstractions.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Produtos.Domain.ValueObjects
{
    public class Preco : ValueObject
    {
        public Preco(decimal precoAtacado, decimal precoVarejo)
        {
            PrecoAtacado = precoAtacado;
            PrecoVarejo = precoVarejo;
        }

        public decimal PrecoAtacado { get; private set; }
        public decimal PrecoVarejo { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PrecoAtacado;
            yield return PrecoVarejo;
        }
    }
}