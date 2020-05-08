using AutoMapper;
using Indra.SelecaoDotNet.Application.Interfaces;
using Indra.SelecaoDotNet.Application.ViewModels;
using Indra.SelecaoDotNet.Dominio.Entities;
using Indra.SelecaoDotNet.Dominio.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Indra.SelecaoDotNet.Application.Services
{
    public class CursoAppService : ICursoAppService
    {
        private readonly IMapper _mapper;
        private readonly ICursoService cursoService;

        public CursoAppService(IMapper mapper, ICursoService cursoService)
        {
            _mapper = mapper;
            this.cursoService = cursoService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public MatriculaViewModel EfetuarPagamento(Guid userId, Guid pagamentoId)
        {
            var matricula = cursoService.EfetuarPagamento(userId, pagamentoId);
            return _mapper.Map<MatriculaViewModel>(matricula);
        }

        public CursoViewModel Obtem(Guid id)
        {
            var curso = cursoService.Obtem(id);
            return _mapper.Map<CursoViewModel>(curso);
        }

        public IEnumerable<CursoViewModel> ObtemTodos()
        {
            return _mapper.Map<IEnumerable<CursoViewModel>>(cursoService.ObtemTodos());
        }

        public MatriculaViewModel RealizarMatricula(Guid usuarioId, Guid cursoid)
        {
            var matricula = cursoService.RealizarMatricula(usuarioId, cursoid);
            return _mapper.Map<MatriculaViewModel>(matricula);

        }
    }
}
