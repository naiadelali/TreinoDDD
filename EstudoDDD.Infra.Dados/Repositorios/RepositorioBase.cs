using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EstudoDDD.Dominio.Interfaces.Repositorios;
using EstudoDDD.Infra.Dados.Contexto;

namespace EstudoDDD.Infra.Dados.Repositorios
{
    public class RepositorioBase<TEntity>:IRepositorioBase<TEntity> where TEntity:class 
    {
        private readonly ProjetoContexto _contexto = new ProjetoContexto();

        public IEnumerable<TEntity> BuscarTudo()
        {
            return _contexto.Set<TEntity>().ToList();
        }

        public TEntity BuscarPorId(int id)
        {
            return _contexto.Set<TEntity>().Find(id);
        }

        public void Atualizar(TEntity obj)
        {
            _contexto.Entry(obj).State = EntityState.Modified;
            _contexto.SaveChanges();

        }

        public void Adicionar(TEntity obj)
        {
            _contexto.Set<TEntity>().Add(obj);
            _contexto.SaveChanges();
        }

        public void Deletar(TEntity obj)
        {
            _contexto.Set<TEntity>().Remove(obj);
            _contexto.SaveChanges();
        }
    }
}
