using System;

namespace Indra.SelecaoDotNet.Dominio.Entities
{
    public class Cartao : Entity
    {

        public string Numero { get; private set; }

        public string Nome { get; private set; }

        public int Codigo { get; private set; }

        public bool Padrao { get; private set; }

        public Guid Usuario_Id { get; set; }

        public Usuario Usuario { get;  set; }


        public Cartao() { }

        public Cartao(Usuario usuario, string numero, string nome, int codigo, bool padrao = false)
        {
            Usuario = usuario;
            Numero = numero;
            Nome = nome;
            Codigo = codigo;
        }

        public void MudarStatus(bool status = true)
        {
            Padrao = status;
        }

    }
}
