using System;
using System.ComponentModel.DataAnnotations;

namespace Indra.SelecaoDotNet.Application.ViewModels
{
    public class CursoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
    }
}
