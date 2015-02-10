using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EstudoDDD.Dominio.Entidades;
using EstudoDDD.Infra.Dados.Configuracoes;

namespace EstudoDDD.Infra.Dados.Contexto
{
    public class ProjetoContexto:DbContext
    {
        public ProjetoContexto()
            :base("LojaDDD")
        { }
        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Configurations.Add(new ProdutoConfiguracao());
        }
    }
}
