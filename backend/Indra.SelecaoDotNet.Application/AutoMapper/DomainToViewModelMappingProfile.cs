using AutoMapper;
using Indra.SelecaoDotNet.Application.ViewModels;
using Indra.SelecaoDotNet.Dominio.Entities;

namespace Indra.SelecaoDotNet.Application.AutoMapper
{
    internal class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Curso, CursoViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();      
            CreateMap<Cartao, CartaoViewModel>();      
            CreateMap<Matricula, MatriculaViewModel>();      
            CreateMap<Pagamento, PagamentoViewModel>();      
        }
    }
}
