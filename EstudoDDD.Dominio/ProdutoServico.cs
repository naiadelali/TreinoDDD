using EstudoDDD.Dominio.Entidades;
using EstudoDDD.Dominio.Interfaces.Repositorios;
using EstudoDDD.Dominio.Interfaces.Servicos;
using EstudoDDD.Dominio.Servicos;

namespace EstudoDDD.Dominio
{
    public class ProdutoServico:ServicoBase<Produto>, IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
            : base(produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
    }
}
