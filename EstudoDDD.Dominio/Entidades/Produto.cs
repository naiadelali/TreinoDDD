using System.ComponentModel.DataAnnotations;

namespace EstudoDDD.Dominio.Entidades
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(250)]
        public string Categoria { get; set; }

        [Required]
        public decimal Preco { get; set; }
    }
}
