using AutoMapper;
using Indra.SelecaoDotNet.Application.Interfaces;
using Indra.SelecaoDotNet.Application.ViewModels;
using Indra.SelecaoDotNet.Dominio.Entities;
using Indra.SelecaoDotNet.Dominio.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Indra.SelecaoDotNet.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IMapper mapper;
        private readonly IUsuarioService usuarioService;

        public UsuarioAppService(IMapper mapper, IUsuarioService usuarioService)
        {
            this.mapper = mapper;
            this.usuarioService = usuarioService;
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<UsuarioViewModel> ObtemTodos()
        {
            return mapper.Map<IEnumerable<UsuarioViewModel>>(usuarioService.ObtemTodos());
        }
        public UsuarioViewModel Obtem(Guid id)
        {
            return mapper.Map<UsuarioViewModel>(usuarioService.Obtem(id));
        }
     

        public void Cadastrar(UsuarioViewModel model)
        {
            var usuario = mapper.Map<Usuario>(model);
            usuarioService.Adiciona(usuario);
        }


        public UsuarioViewModel Login(LoginModel model)
        {
            var usuario = usuarioService.Obtem(model.Email, model.Senha);

            return mapper.Map<UsuarioViewModel>(usuario);
        }

        public void AdicionarCartao(Guid userId, CartaoViewModel model)
        {
            var cartao = mapper.Map<Cartao>(model);
            usuarioService.AdicionarCartao(userId, cartao);
        }

        public IEnumerable<CartaoViewModel> ObtemCartoes(Guid userId)
        {
            var cartoes = usuarioService.ObtemCartoes(userId);
            return mapper.Map<IEnumerable<CartaoViewModel>>(cartoes);
        }

        public void CartaoPadrao(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}