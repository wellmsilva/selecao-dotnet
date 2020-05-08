using Indra.SelecaoDotNet.Dominio.Entities;
using Indra.SelecaoDotNet.Dominio.Interfaces.Repositories;
using Indra.SelecaoDotNet.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indra.SelecaoDotNet.Infra.Data.Repositories
{
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        public CursoRepository(BaseContext context) : base(context)
        {
        }
    }
}
