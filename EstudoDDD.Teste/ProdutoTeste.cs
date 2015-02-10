using System;
using EstudoDDD.Dominio.Entidades;
using EstudoDDD.Dominio.Interfaces.Repositorios;
using EstudoDDD.Dominio.Servicos;
using EstudoDDD.Infra.Dados.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstudoDDD.Teste
{
    [TestClass]
    public class ProdutoTeste
    {
        [TestMethod]
        public void BuscarTudoProduto()
        {
            IProdutoRepositorio _produtoRepositorio = new ProdutoRepositorio();
            ServicoBase<Produto> _servicoBase = new ServicoBase<Produto>(_produtoRepositorio);

            Produto resultadoProduto = new Produto()
            {
                ProdutoId = 1,
                Descricao = "Camiseta",
                Preco = 3,
                Categoria = "Roupas"
            };

            var produto = _servicoBase.BuscarPorId(1);

            Assert.AreEqual(resultadoProduto.ProdutoId, produto.ProdutoId);


        }
    }
}
