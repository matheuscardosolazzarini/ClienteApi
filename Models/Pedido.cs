using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteApi.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "A Data do Pedido é obrigatória.")]
        public DateTime DataPedido { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatória.")]
        [StringLength(200, ErrorMessage = "A Descrição não pode ter mais de 200 caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Valor do pedido é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")] 
        [Range(0.01, 9999999.99, ErrorMessage = "O Valor deve ser maior que zero.")]
        public decimal Valor { get; set; }

        public Cliente? Cliente { get; set; }
    }
}