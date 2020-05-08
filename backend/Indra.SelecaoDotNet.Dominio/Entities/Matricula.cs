using Indra.SelecaoDotNet.Dominio.Enums;
using System;

namespace Indra.SelecaoDotNet.Dominio.Entities
{
    public class Matricula : Entity
    {
        public Guid Usuario_Id { get; private set; }
        public Guid Curso_Id { get; private set; }

        public Guid Pagamento_Id { get; private set; }
        public DateTime Data { get; private set; }
        public Usuario Usuario { get; private set; }
        public Curso Curso { get; private set; }
        public Pagamento Pagamento { get; private set; }

        public StatusMatricula StatusMatricula => Pagamento?.Efetuado == true ? StatusMatricula.ATIVA : StatusMatricula.PENDENTE;

   

        public Matricula() { }

        public Matricula(Curso curso, Usuario usuario, DateTime data)
        {
            Curso = curso;
            Usuario = usuario;
            Data = data;
        }

        internal void GerarPagamento()
        {
            Pagamento = new Pagamento(this, Usuario, Curso.Preco);
        }

        internal void EfetuaPagamento(Cartao cartao)
        {
            if (Pagamento == null)
                throw new Exception("Boleto não existe");
            Pagamento.EfetuaPagamento(cartao);


        }
    }
}
