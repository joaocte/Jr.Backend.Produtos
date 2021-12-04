using Jr.Backend.Produtos.Infrastructure.Entity.Comum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Jr.Backend.Produtos.Infrastructure.Entity
{
    public class Fornecedor
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        public bool AceiteTermosDeUso { get; set; }
        public decimal CapitalSocial { get; set; }
        public string Celular { get; set; }
        public int CnaeFiscal { get; set; }
        public string CnaeFiscalDescricao { get; set; }
        public List<CnaesSecundario> CnaesSecundarios { get; set; }
        public string Cnpj { get; set; }
        public int CodigoNaturezaJuridica { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataExclusaoDoSimples { get; set; }
        public DateTime DataInicioAtividade { get; set; }
        public DateTime? DataOpcaoPeloSimples { get; set; }
        public DateTime DataSituacaoCadastral { get; set; }
        public DateTime? DataSituacaoEspecial { get; set; }
        public string DescricaoMatrizFilial { get; set; }
        public string DescricaoPorte { get; set; }
        public string DescricaoSituacaoCadastral { get; set; }

        public IEnumerable<string> EmailContato { get; set; }
        public IEnumerable<string> EmailFatura { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public int IdentificadorMatrizFilial { get; set; }
        public InformacoesBancarias InformacoesBancarias { get; set; }
        public int MotivoSituacaoCadastral { get; set; }
        public string NomeCidadeExterior { get; set; }
        public string NomeContato { get; set; }
        public string NomeFantasia { get; set; }
        public bool OpcaoPeloMei { get; set; }
        public bool OpcaoPeloSimples { get; set; }
        public int Porte { get; set; }
        public List<Qsa> Qsa { get; set; }
        public int QualificacaoDoResponsavel { get; set; }
        public string RazaoSocial { get; set; }
        public int SituacaoCadastral { get; set; }
        public string SituacaoEspecial { get; set; }
        public IEnumerable<string> Telefones { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string StatusCadastro { get; set; }
    }
}