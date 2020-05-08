using System;
using System.Collections.Generic;
using System.Text;

namespace Indra.SelecaoDotNet.Dominio.Interfaces.Services
{
    public interface IService<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> ObtemTodos();
        TEntity Obtem(object id);
        void Adiciona(TEntity entity);
        void Atualiza(TEntity entity);
        void Deleta(TEntity entity);
    }
}
