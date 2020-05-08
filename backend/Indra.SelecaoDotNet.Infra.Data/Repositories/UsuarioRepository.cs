using Indra.SelecaoDotNet.Dominio.Entities;
using Indra.SelecaoDotNet.Dominio.Interfaces.Repositories;
using Indra.SelecaoDotNet.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Indra.SelecaoDotNet.Infra.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(BaseContext context) : base(context)
        {
        }

        public Usuario Obtem(string email, string senha)
        {
            return _db.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }
    }
}
