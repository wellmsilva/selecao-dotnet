using AutoMapper;
using Indra.SelecaoDotNet.Application.ViewModels;
using Indra.SelecaoDotNet.Dominio.Entities;

namespace Indra.SelecaoDotNet.Application.AutoMapper
{
    internal class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CursoViewModel, Curso>();
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<CartaoViewModel, Cartao>();
            CreateMap< MatriculaViewModel, Matricula>();
            CreateMap<PagamentoViewModel, Pagamento>();
        }
    }
}
