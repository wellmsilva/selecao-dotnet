using System;
using System.Collections.Generic;
using System.Text;

namespace Indra.SelecaoDotNet.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
    }
}
