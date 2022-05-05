using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Haven.Models
{
    public class Depoimento
    {
        [Key]
        public int Id { get; set; }
        public bool Anonimo { get; set; }
        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }
        [Required]
        [StringLength(100)]
        public string ModalidadeCrime { get; set; }
        public DateTime DataInclusao { get; set; }
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        [Column("idEndereco")]
        public int IdEndereco { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }
    }
}
