using EstudoDDD.Dominio.Entidades;
using EstudoDDD.Dominio.Interfaces.Repositorios;

namespace EstudoDDD.Infra.Dados.Repositorios
{
    public class ProdutoRepositorio:RepositorioBase<Produto>,IProdutoRepositorio
    {
    }
}
