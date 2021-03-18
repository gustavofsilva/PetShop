using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back._Models
{
    public class Alojamento
    {
        public Alojamento()
        {
            Ocupado = "livre";
        }
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public String Ocupado { get; set; }
        
        [ForeignKey("Animal")] 
        public int? AnimalId { get; set; } 
        public Animal Animal { get; set; }
    }
}