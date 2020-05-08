using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Indra.SelecaoDotNet.Application.ViewModels
{
    public class LoginModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Email { get; set; }


        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Senha { get; set; }
    }
}
