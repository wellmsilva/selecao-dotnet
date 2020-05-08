using Indra.SelecaoDotNet.Dominio.Entities;
using System;

namespace Indra.SelecaoDotNet.Dominio.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario Obtem(string email, string senha);
   
    }
}
