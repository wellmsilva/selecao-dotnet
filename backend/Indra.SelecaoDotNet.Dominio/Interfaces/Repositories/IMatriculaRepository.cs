using Indra.SelecaoDotNet.Dominio.Entities;
using System;

namespace Indra.SelecaoDotNet.Dominio.Interfaces.Repositories
{
    public interface IMatriculaRepository : IRepository<Matricula>
    {
        Matricula ObtemPendentePagamento(Guid pagamentoId);
    }
}
