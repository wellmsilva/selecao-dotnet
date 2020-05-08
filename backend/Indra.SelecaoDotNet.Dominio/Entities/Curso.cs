using System;
using System.Collections.Generic;

namespace Indra.SelecaoDotNet.Dominio.Entities
{
    public class Curso : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public double Preco { get; private set; }

        public IEnumerable<Matricula> Matriculas { get; private set; }

        protected Curso()
        {
            Matriculas = new HashSet<Matricula>();
        }

        public Curso(string nome, string descricao = null, double? preco = 0)
            : base()
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
            Preco = preco.Value;
        }
    }
}
