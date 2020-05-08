using Indra.SelecaoDotNet.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indra.SelecaoDotNet.Dominio.Interfaces.Services
{
    public interface IUsuarioService : IService<Usuario>
    {
        Usuario Obtem(string email, string senha);
        void AdicionarCartao(Guid userId, Cartao cartao);
        IEnumerable<Cartao> ObtemCartoes(Guid userId);
    }
}
