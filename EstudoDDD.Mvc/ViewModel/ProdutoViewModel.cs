using System.ComponentModel.DataAnnotations;

namespace EstudoDDD.Mvc.ViewModel
{
    public class ProdutoViewModel
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