using System;
using System.Collections.Generic;
using System.Text;

namespace Indra.SelecaoDotNet.Application.ViewModels
{
   public class MatriculaViewModel
    {

        public Guid Usuario_Id { get;  set; }
        public Guid Curso_Id { get;  set; }
        public DateTime Data { get;  set; }
        public Guid Pagamento_Id { get;  set; }
        public string StatusMatricula { get; set; }
    }
}
