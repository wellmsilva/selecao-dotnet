using Indra.SelecaoDotNet.Dominio.Entities;
using System;

namespace Indra.SelecaoDotNet.Dominio.Interfaces.Services
{
    public interface ICursoService : IService<Curso>
    {
        Matricula RealizarMatricula(Guid userId, Guid cursoid);
        Matricula EfetuarPagamento(Guid userId, Guid pagamentoId);
    }
}
