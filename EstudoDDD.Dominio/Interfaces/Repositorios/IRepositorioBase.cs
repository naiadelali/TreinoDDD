using System.Collections;
using System.Collections.Generic;

namespace EstudoDDD.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> BuscarTudo();
        TEntity BuscarPorId(int id);
        void Atualizar(TEntity obj);
        void Adicionar(TEntity obj);
        void Deletar(TEntity obj);
 }
}
