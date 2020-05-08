using Indra.SelecaoDotNet.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Indra.SelecaoDotNet.Application.Interfaces
{
    public interface ICursoAppService : IDisposable
    {
        IEnumerable<CursoViewModel> ObtemTodos();
        CursoViewModel Obtem(Guid id);
        MatriculaViewModel RealizarMatricula(Guid usuarioId, Guid id);
        MatriculaViewModel EfetuarPagamento(Guid userId, Guid pagamentoId);
    }
}
