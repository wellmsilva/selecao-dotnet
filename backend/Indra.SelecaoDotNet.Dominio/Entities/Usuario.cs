using System;
using System.Collections.Generic;

namespace Indra.SelecaoDotNet.Dominio.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public string Senha { get; private set; }

        public Usuario()
        {
            Cartoes = new HashSet<Cartao>();
            Matriculas = new HashSet<Matricula>();
            Pagamentos = new HashSet<Pagamento>();
        }
        public Usuario(string nome, string email, string senha, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            DataNascimento = dataNascimento;
        }

        public IEnumerable<Cartao> Cartoes { get; private set; }
        public IEnumerable<Matricula> Matriculas { get; private set; }
        public IEnumerable<Pagamento> Pagamentos { get; private set; }

    }
}
