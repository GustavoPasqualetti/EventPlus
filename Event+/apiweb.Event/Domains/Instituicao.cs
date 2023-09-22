using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.Event.Domains
{
    [Table(nameof(Instituicao))]
    [Index(nameof(CNPJ), IsUnique = true )]
    public class Instituicao
    {
        [Key]
        public Guid IdInstituicao { get; set; } = Guid.NewGuid();

        [Column(TypeName ="CHAR(14)")]
        [Required(ErrorMessage ="CNPJ obrigatorio")]
        public string? CNPJ { get; set; }

        [Column(TypeName ="VARCHAR(50)")]
        [Required(ErrorMessage ="Endereco obrigatorio")]
        public string? Endereco { get; set; }

        [Column(TypeName ="VARCHAR(50)")]
        [Required(ErrorMessage = "Nome da instituicao obrigatorio")]
        public string? NomeFantasia { get; set; }
    }
}
