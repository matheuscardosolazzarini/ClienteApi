using System.ComponentModel.DataAnnotations;

namespace ClienteApi.Models
{
    public abstract class Pessoa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome deve ter entre 3 e 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O formato do Email é inválido.")]
        public string Email { get; set; } = string.Empty;

        [StringLength(15, ErrorMessage = "O Telefone não pode ter mais de 15 caracteres.")]
        public string? Telefone { get; set; }
    }
}