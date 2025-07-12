using System.ComponentModel.DataAnnotations;

namespace ClienteApi.Models
{
    public class Cliente : Pessoa
    {
        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O CPF deve ter entre 11 e 14 caracteres.")]
        public string CPF { get; set; } = string.Empty;

        public DateTime? DataNascimento { get; set; }

        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}