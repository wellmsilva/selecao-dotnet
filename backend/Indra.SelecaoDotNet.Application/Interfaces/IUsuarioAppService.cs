using Indra.SelecaoDotNet.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Indra.SelecaoDotNet.Application.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        IEnumerable<UsuarioViewModel> ObtemTodos();
        UsuarioViewModel Obtem(Guid id);
        void Cadastrar(UsuarioViewModel model);
        UsuarioViewModel Login(LoginModel model);
        void AdicionarCartao(Guid userId, CartaoViewModel model);
        IEnumerable<CartaoViewModel> ObtemCartoes(Guid userId);
        void CartaoPadrao(Guid id);
    }
}