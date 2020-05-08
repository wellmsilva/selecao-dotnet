using Indra.SelecaoDotNet.Dominio.Entities;
using Indra.SelecaoDotNet.Dominio.Interfaces.Repositories;
using Indra.SelecaoDotNet.Dominio.Interfaces.Services;
using Indra.SelecaoDotNet.Dominio.Services;
using Indra.SelecaoDotNet.Infra.Data.Contexts;
using Indra.SelecaoDotNet.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Indra.SelecaoDotNet.Test
{
    [TestClass]
    public class UsuarioServiceTest
    {
        private BaseContext context;      
        private IUsuarioService usuarioService;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BaseContext>()
                          .UseInMemoryDatabase(databaseName: "BaseContext_Test")
                          .Options;

            context = new BaseContext(options);          
            usuarioService = new UsuarioService(new UsuarioRepository(context), new CartaoRepository(context));
        }


        [TestMethod]
        public void CadastraUsuario_Test()
        {
            var usuario = new Usuario("Tete", "teste@gmail.com", "123456", DateTime.Now.AddYears(-20));
            usuarioService.Adiciona(usuario);
            var user = usuarioService.Obtem("teste@gmail.com", "123456");
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void CadastraUsuarioSenhaErrada_Test()
        {
            var usuario = new Usuario("Tete", "teste@gmail.com", "123456", DateTime.Now.AddYears(-20));
            usuarioService.Adiciona(usuario);
            var user = usuarioService.Obtem("teste@gmail.com", "1234565");
            Assert.IsNull(user);
        }
    }
}
