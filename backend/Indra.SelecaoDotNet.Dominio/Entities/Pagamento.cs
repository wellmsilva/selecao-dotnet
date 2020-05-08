using System;
using System.Collections.Generic;
using System.Text;

namespace Indra.SelecaoDotNet.Dominio.Entities
{
    public class Pagamento : Entity
    {

        public Pagamento()
        {
        }

        public Pagamento(Matricula matricula, Usuario usuario, double valor)
        {
            Matricula = matricula;
            Usuario = usuario;
            Valor = valor;
            Data = DateTime.Now;
        }

        public DateTime Data { get; private set; }
        public DateTime? DataPagamento { get; private set; }
        public double Valor { get; private set; }

        public bool Efetuado => DataPagamento.HasValue;
        public Guid Usuario_Id { get; set; }
        public Guid Matricula_Id { get; private set; }
       
        public Guid Cartao_Id { get; set; }


        public virtual Cartao Cartao { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public virtual Matricula Matricula { get; private set; }

        internal void EfetuaPagamento(Cartao cartao)
        {
            Cartao = cartao;
            DataPagamento = DateTime.Now;
        }
    }
}
