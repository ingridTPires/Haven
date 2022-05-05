using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Haven.Models
{
    public class Ocorrencia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }
        [Required]
        [StringLength(100)]
        public string ModalidadeCrime { get; set; }
    }
}
