using Indra.SelecaoDotNet.Dominio.Entities;
using Indra.SelecaoDotNet.Dominio.Interfaces.Repositories;
using Indra.SelecaoDotNet.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Indra.SelecaoDotNet.Infra.Data.Repositories
{
    public class CartaoRepository : Repository<Cartao>, ICartaoRepository
    {
        public CartaoRepository(BaseContext context) : base(context)
        {
        }

        public Cartao ObtemPadraoUsuario(Guid userId)
        {
            return _db.Cartoes.FirstOrDefault(x => x.Usuario_Id == userId && x.Padrao);
        }

        public IEnumerable<Cartao> ObtemPorUsuario(Guid userId)
        {
            return _db.Cartoes.Where(x => x.Usuario_Id == userId).OrderByDescending(x => x.Padrao);
        }
    }
}
