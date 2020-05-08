using Indra.SelecaoDotNet.Dominio.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indra.SelecaoDotNet.Infra.Data.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        public void Enviar(string para, string titulo, string corpo)
        {            
            Console.WriteLine($"Enviando email para :{para}. Titulo => {titulo} | Corpo  => {corpo}");
        }
    }
}
