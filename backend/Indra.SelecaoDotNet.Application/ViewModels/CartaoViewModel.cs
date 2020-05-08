using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Indra.SelecaoDotNet.Application.ViewModels
{
    public class CartaoViewModel
    {
        [Required]
        public string Numero { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Codigo { get; set; }

        public bool Padrao { get;  set; }
    }
}
