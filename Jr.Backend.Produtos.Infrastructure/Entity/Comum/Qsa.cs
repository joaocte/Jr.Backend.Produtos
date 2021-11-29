using System;

namespace Jr.Backend.Produtos.Infrastructure.Entity.Comum
{
    public class Qsa
    {
        public int IdentificadorDeSocio { get; set; }

        public string NomeSocio { get; set; }

        public string CnpjCpfDoSocio { get; set; }

        public int CodigoQualificacaoSocio { get; set; }

        public decimal PercentualCapitalSocial { get; set; }

        public DateTime? DataEntradaSociedade { get; set; }

        public string CpfRepresentanteLegal { get; set; }

        public string NomeRepresentanteLegal { get; set; }

        public string CodigoQualificacaoRepresentanteLegal { get; set; }
    }
}