using Indra.SelecaoDotNet.Dominio.Interfaces.Repositories;
using Indra.SelecaoDotNet.Infra.Data.Contexts;
using System;
using System.Collections.Generic;

namespace Indra.SelecaoDotNet.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BaseContext _db;

        public Repository(BaseContext context)
        {
            _db = context;
        }

        public void Adiciona(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
            _db.SaveChanges();
        }

        public void Deleta(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
            _db.SaveChanges();
        }


        public void Atualiza(TEntity entity)
        {          
            _db.SaveChanges();
        }

        public TEntity Obtem(object id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TEntity> ObtemTodos()
        {
            return _db.Set<TEntity>();
        }
    }
}
