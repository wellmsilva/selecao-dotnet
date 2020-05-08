using Indra.SelecaoDotNet.Dominio.Entities;
using Indra.SelecaoDotNet.Dominio.Interfaces.Repositories;
using Indra.SelecaoDotNet.Infra.Data.Contexts;
using System;
using System.Linq;

namespace Indra.SelecaoDotNet.Infra.Data.Repositories
{
    public class MatriculaRepository : Repository<Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(BaseContext context) : base(context)
        {
        }

        public Matricula ObtemPendentePagamento(Guid pagamentoId)
        {
            return _db.Matriculas.FirstOrDefault(x => x.Pagamento_Id == pagamentoId && !x.Pagamento.DataPagamento.HasValue);
        }
    }
}
