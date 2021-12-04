using AutoMapper;
using Jr.Backend.Produtos.Infrastructure.Entity;
using Jr.Backend.Produtos.Infrastructure.Entity.Comum;
using Jror.Backend.Message.Events.Fornecedor.Events;

namespace Jr.Backend.Produtos.Application.AutoMapper
{
    public class MappingProfileToEntity : Profile
    {
        public MappingProfileToEntity()
        {
            CreateMap<Jror.Backend.Message.Share.Fornecedor.InformacoesBancarias, InformacoesBancarias>();
            CreateMap<Jror.Backend.Message.Share.Fornecedor.Endereco, Endereco>();
            CreateMap<Jror.Backend.Message.Share.Fornecedor.Qsa, Qsa>();
            CreateMap<Jror.Backend.Message.Share.Fornecedor.CnaesSecundario, CnaesSecundario>();
            CreateMap<FornecedorCadastradoEvent, Fornecedor>();
        }
    }
}