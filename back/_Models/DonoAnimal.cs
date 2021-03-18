using System.ComponentModel.DataAnnotations;

namespace back._Models
{
    public class DonoAnimal
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        public string Nome { get; set; }

        [StringLength(250)]
        public string Endereco { get; set; }
        
        [StringLength(50)]
        public string Telefone { get; set; }
    }
}