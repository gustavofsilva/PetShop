using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace back._Models
{
    public class PetShop
    {
        public PetShop()
        {
            
        }
        
        [Key]
        public int id { get; set; }
        public IEnumerable<Alojamento> Alojamentos { get; set; }
    }
}