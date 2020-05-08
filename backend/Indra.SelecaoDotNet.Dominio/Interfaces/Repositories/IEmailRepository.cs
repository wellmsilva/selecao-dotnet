using System;
using System.Collections.Generic;
using System.Text;

namespace Indra.SelecaoDotNet.Dominio.Interfaces.Repositories
{
    public interface IEmailRepository
    {
        void Enviar(string para,string titulo, string corpo);
    }
}
