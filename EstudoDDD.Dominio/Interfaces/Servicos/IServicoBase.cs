using System.Collections.Generic;
using EstudoDDD.Dominio.Interfaces.Repositorios;

namespace EstudoDDD.Dominio.Interfaces.Servicos
{
    public interface IServicoBase<TEntity>
    {
        IEnumerable<TEntity> BuscarTudo();
        TEntity BuscarPorId(int id);
        void Atualizar(TEntity obj);
        void Adicionar(TEntity obj);
        void Deletar(TEntity obj);
    }
}
