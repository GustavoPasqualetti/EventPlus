using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.Event.Domains
{
    [Table(nameof(Evento))]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName ="DATE")]
        [Required(ErrorMessage ="Data do evento obrigatoria")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName ="VARCHAR(100)") ]
        [Required(ErrorMessage = "Nome obrigatorio")]
        public string? NomeEvento { get; set; }

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage = "Descricao obrigatoria")]
        public string? Descricao { get; set;  }

        [Required(ErrorMessage ="Tipo do evento obrigatorio")]
        public Guid IdTipoEvento { get; set; }

        [ForeignKey(nameof(IdTipoEvento))]
        public TiposEvento? TiposEvento { get; set; }

        [Required(ErrorMessage ="Instituicao obrigatoria")]
        public Guid IdInstituicao { get; set; }

        [ForeignKey(nameof(IdInstituicao))]
        public Instituicao? Instituicao { get; set; } 
    }
}