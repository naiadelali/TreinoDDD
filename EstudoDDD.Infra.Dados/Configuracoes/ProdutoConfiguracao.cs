using System.Data.Entity.ModelConfiguration;
using EstudoDDD.Dominio.Entidades;

namespace EstudoDDD.Infra.Dados.Configuracoes
{
    public class ProdutoConfiguracao:EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguracao()
        {
            HasKey(obj => obj.ProdutoId);
        }
    }
}
