using System.Collections.Generic;

namespace EstudoDDD.Aplicacao.Interfaces
{
    public interface IAppServicoBase<TEntity> where TEntity:class 
    {
        IEnumerable<TEntity> BuscarTudo();
        TEntity BuscarPorId(int id);
        void Atualizar(TEntity obj);
        void Adicionar(TEntity obj);
        void Deletar(TEntity obj);
    }
}
