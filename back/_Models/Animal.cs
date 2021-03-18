using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back._Models
{
    public class Animal
    {
        public Animal()
        {
            EstadoSaude = "Em Tratamento";
        }
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        public string Nome { get; set; }        

        [StringLength(150)]
        public string MotivoInternacao { get; set; }

        [StringLength(150)]
        public string EstadoSaude { get; set; }

        [StringLength(150)]
        public string Foto { get; set; }

        [ForeignKey("DonoAnimal")] 
        public int? DonoAnimalId { get; set; }

        
        public DonoAnimal Dono { get; set; }
    }
}