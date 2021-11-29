using AutoMapper;
using Jr.Backend.Message.Events.Fornecedor.Events;
using Jr.Backend.Produtos.Infrastructure.Entity;
using Jr.Backend.Produtos.Infrastructure.Entity.Comum;

namespace Jr.Backend.Produtos.Application.AutoMapper
{
    public class MappingProfileToEntity : Profile
    {
        public MappingProfileToEntity()
        {
            CreateMap<Message.Share.Fornecedor.InformacoesBancarias, InformacoesBancarias>();
            CreateMap<Message.Share.Fornecedor.Endereco, Endereco>();
            CreateMap<Message.Share.Fornecedor.Qsa, Qsa>();
            CreateMap<Message.Share.Fornecedor.CnaesSecundario, CnaesSecundario>();
            CreateMap<FornecedorCadastradoEvent, Fornecedor>();
        }
    }
}