using System.Collections.Generic;
using EstudoDDD.Aplicacao.Interfaces;
using EstudoDDD.Dominio.Interfaces.Servicos;

namespace EstudoDDD.Aplicacao
{
    public class AppServicoBase<TEntity>:IAppServicoBase<TEntity> where TEntity:class
    {
        private readonly IServicoBase<TEntity> _servicoBase;

        public AppServicoBase(IServicoBase<TEntity> servicoBase)
        {
            _servicoBase = servicoBase;
        }

        public IEnumerable<TEntity> BuscarTudo()
        {
            return _servicoBase.BuscarTudo();
        }

        public TEntity BuscarPorId(int id)
        {
            return _servicoBase.BuscarPorId(id);
        }

        public void Atualizar(TEntity obj)
        {
           _servicoBase.Atualizar(obj);
        }

        public void Adicionar(TEntity obj)
        {
            _servicoBase.Adicionar(obj);
        }

        public void Deletar(TEntity obj)
        {
           _servicoBase.Deletar(obj);
        }
    }
}
