using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Haven.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Logradouro { get; set; }
        [Required]
        [StringLength(8)]
        public string Cep { get; set; }
        [Required]
        [StringLength(100)]
        public string Bairro { get; set; }
        [Required]
        [StringLength(100)]
        public string Cidade { get; set; }
        [Required]
        [StringLength(2)]
        public string UF { get; set; }

        public ICollection<Ocorrencia> Ocorrencias { get; set; } = new List<Ocorrencia>();
        public ICollection<Depoimento> Depoimentos { get; set; } = new List<Depoimento>();
    }
}
