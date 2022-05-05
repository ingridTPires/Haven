using System.ComponentModel.DataAnnotations;

namespace Haven.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }
        [StringLength(9)]
        public string Telefone { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Senha { get; set; }
        public bool Administrador { get; set; }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
