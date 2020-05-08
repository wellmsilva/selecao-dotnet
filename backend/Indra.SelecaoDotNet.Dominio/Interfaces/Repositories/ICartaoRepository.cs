using Indra.SelecaoDotNet.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indra.SelecaoDotNet.Dominio.Interfaces.Repositories
{
    public interface ICartaoRepository : IRepository<Cartao>
    {
        IEnumerable<Cartao> ObtemPorUsuario(Guid userId);
        Cartao ObtemPadraoUsuario(Guid userId);
    }
}
