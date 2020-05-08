using System;
using System.Collections.Generic;
using System.Text;

namespace Indra.SelecaoDotNet.Dominio.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Obtem(object id);
        IEnumerable<TEntity> ObtemTodos();
        void Adiciona(TEntity entity);
        void Deleta(TEntity entity);
        void Atualiza(TEntity entity); 
    }
}
