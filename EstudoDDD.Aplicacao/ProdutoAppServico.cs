using EstudoDDD.Aplicacao.Interfaces;
using EstudoDDD.Dominio.Entidades;
using EstudoDDD.Dominio.Interfaces.Servicos;

namespace EstudoDDD.Aplicacao
{
    public class ProdutoAppServico:AppServicoBase<Produto>,IProdutoAppServico
    {
        private readonly IProdutoServico _produtoServico;

        public ProdutoAppServico(IProdutoServico produtoServico)
            :base(produtoServico)
        {
            _produtoServico = produtoServico;
        }
    }
}
