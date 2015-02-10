using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using EstudoDDD.Dominio.Interfaces.Repositorios;
using EstudoDDD.Dominio.Interfaces.Servicos;

namespace EstudoDDD.Dominio.Servicos
{
    public class ServicoBase<TEntity> :IDisposable, IServicoBase<TEntity> where TEntity:class
    {
        private readonly IRepositorioBase<TEntity> _repositorioBase;

        public ServicoBase(IRepositorioBase<TEntity> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }

        public IEnumerable<TEntity> BuscarTudo()
        {
            return _repositorioBase.BuscarTudo();
        }

        public TEntity BuscarPorId(int id)
        {
            return _repositorioBase.BuscarPorId(id);
        }

        public void Atualizar(TEntity obj)
        {
            _repositorioBase.Atualizar(obj);
        }

        public void Adicionar(TEntity obj)
        {
            _repositorioBase.Adicionar(obj);
        }

        public void Deletar(TEntity obj)
        {
            _repositorioBase.Deletar(obj);
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
