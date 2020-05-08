using Indra.SelecaoDotNet.Dominio.Entities;
using Indra.SelecaoDotNet.Dominio.Interfaces.Repositories;
using Indra.SelecaoDotNet.Dominio.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Indra.SelecaoDotNet.Dominio.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ICartaoRepository cartaoRepository;

        public UsuarioService(IUsuarioRepository repository, ICartaoRepository cartaoRepository) : base(repository)
        {
            this.usuarioRepository = repository;
            this.cartaoRepository = cartaoRepository;
        }

        public Usuario Obtem(string email, string senha)
        {
            return usuarioRepository.Obtem(email, senha);
        }

        public void AdicionarCartao(Guid userId, Cartao cartao)
        {
            var usuario = usuarioRepository.Obtem(userId);
            cartao.Usuario = usuario;

            cartaoRepository.Adiciona(cartao);
        }



        public IEnumerable<Cartao> ObtemCartoes(Guid userId)
        {
            return cartaoRepository.ObtemPorUsuario(userId);
        }
    }
}
