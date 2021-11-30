using AutoMapper;
using Jr.Backend.Message.Events.Fornecedor.Events;
using Jror.Backend.Produtos.Infrastructure.Entity;
using Jror.Backend.Produtos.Infrastructure.Entity.Comum;

namespace Jror.Backend.Produtos.Application.AutoMapper
{
    public class MappingProfileToEntity : Profile
    {
        public MappingProfileToEntity()
        {
            CreateMap<Jr.Backend.Message.Share.Fornecedor.InformacoesBancarias, InformacoesBancarias>();
            CreateMap<Jr.Backend.Message.Share.Fornecedor.Endereco, Endereco>();
            CreateMap<Jr.Backend.Message.Share.Fornecedor.Qsa, Qsa>();
            CreateMap<Jr.Backend.Message.Share.Fornecedor.CnaesSecundario, CnaesSecundario>();
            CreateMap<FornecedorCadastradoEvent, Fornecedor>();
        }
    }
}