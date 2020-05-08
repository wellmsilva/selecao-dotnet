using Indra.SelecaoDotNet.Dominio.Interfaces.Repositories;
using Indra.SelecaoDotNet.Dominio.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indra.SelecaoDotNet.Dominio.Services
{
    public class BaseService<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Adiciona(TEntity entity)
        {
            _repository.Adiciona(entity);
        }

        public void Atualiza(TEntity entity)
        {
            _repository.Atualiza(entity);
        }

        public void Deleta(TEntity entity)
        {
            _repository.Deleta(entity);
        }



        public TEntity Obtem(object id)
        {
            return _repository.Obtem(id);
        }

        public IEnumerable<TEntity> ObtemTodos()
        {
            return _repository.ObtemTodos();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
