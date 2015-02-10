using System.Collections.Generic;
using System.Data.SqlClient;
using EstudoDDD.Dominio.Entidades;
using EstudoDDD.Dominio.Interfaces.Repositorios;
using EstudoDDD.Infra.Dados.Contexto;


namespace EstudoDDD.Infra.Dados.RepositoriosNormal
{
    public class ProdutoRepositorioNormal: IProdutoRepositorio
    {
        private readonly ProjetoContextoNormal _projetoContexto;
        public ProdutoRepositorioNormal()
        {
            _projetoContexto = ProjetoContextoNormal.Create();
        }
        public IEnumerable<Produto> BuscarTudo()
        {
            throw new System.NotImplementedException();
        }

        public Produto BuscarPorId(int id)
        {
            Produto produto = new Produto();
            SqlDataReader reader = null;
            try
            {
                string query = "SELECT * FROM Produtoes WHERE ProdutoId = @ProdutoId";
                _projetoContexto.OpenConnection();
                reader = _projetoContexto.ExecuteDataReader(query, new SqlParameter("ProdutoId", id));
                while (reader.Read())
                {
                    produto.ProdutoId = (int)reader["ProdutoId"];
                    produto.Preco = (decimal)reader["Preco"];
                    produto.Descricao = (string)reader["Descricao"];
                    produto.Categoria = (string)reader["Categoria"];
                }
                reader.Close();
                this._projetoContexto.CloseConection();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                this._projetoContexto.CloseConection();
            }
            return produto;
        }

        public void Atualizar(Produto obj)
        {
            throw new System.NotImplementedException();
        }

        public void Adicionar(Produto obj)
        {
            throw new System.NotImplementedException();
        }

        public void Deletar(Produto obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
