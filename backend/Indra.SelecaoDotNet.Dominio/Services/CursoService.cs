using Indra.SelecaoDotNet.Dominio.Entities;
using Indra.SelecaoDotNet.Dominio.Interfaces.Repositories;
using Indra.SelecaoDotNet.Dominio.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indra.SelecaoDotNet.Dominio.Services
{
    public class CursoService : BaseService<Curso>, ICursoService
    {
        private readonly ICursoRepository repository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMatriculaRepository matriculaRepository;
        private readonly ICartaoRepository cartaoRepository;
        private readonly IEmailRepository emailRepository;

        public CursoService(ICursoRepository repository, IUsuarioRepository usuarioRepository,
            IMatriculaRepository matriculaRepository, ICartaoRepository cartaoRepository,
            IEmailRepository emailRepository) : base(repository)
        {
            this.repository = repository;
            this.usuarioRepository = usuarioRepository;
            this.matriculaRepository = matriculaRepository;
            this.cartaoRepository = cartaoRepository;
            this.emailRepository = emailRepository;
        }

        public IUsuarioRepository UsuarioRepository { get; }
        public ICartaoRepository CartaoRepository { get; }

        public Matricula EfetuarPagamento(Guid userId, Guid pagamentoId)
        {
            var cartao = cartaoRepository.ObtemPadraoUsuario(userId);
            if (cartao == null)
                throw new Exception("Nenhum cartão ativo");

            var matricula = matriculaRepository.ObtemPendentePagamento(pagamentoId);
            if(matricula == null)
                throw new Exception("A matrícula já foi paga anteriormente");

            matricula.EfetuaPagamento(cartao);
            
            return matricula;
        }

        public Matricula RealizarMatricula(Guid usuarioId, Guid cursoid)
        {
            var usuario = usuarioRepository.Obtem(usuarioId);
            var curso = repository.Obtem(cursoid);
            if(usuario != null && curso != null)
            {
                var matricula = new Matricula(curso, usuario, DateTime.Now);
                matricula.GerarPagamento();
                matriculaRepository.Adiciona(matricula);
                emailRepository.Enviar(usuario.Email, "CursosOn", $"Ola {usuario.Nome} \n Sua matrícula foi realizada com sucesso");
                return matricula;
            }
            return null;
        }
    }
}
