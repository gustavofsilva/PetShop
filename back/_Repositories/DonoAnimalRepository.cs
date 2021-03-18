using System.Collections.Generic;
using back._Data;
using back._Interfaces;
using back._Models;

namespace back._Repositories
{
    public class DonoAnimalRepository : IDonoAnimalRepository
    {
        private readonly PetShopContext _contexto;       

        public DonoAnimalRepository(PetShopContext contexto)
        {
            _contexto = contexto;
        }   

        public DonoAnimal CreateDono(DonoAnimal dono)
        {
            _contexto.DonosAnimais.Add(dono);
            _contexto.SaveChanges();
            return dono;
        }

        public IEnumerable<DonoAnimal> donosAnimais => _contexto.DonosAnimais; 

        public void UpdateDono(DonoAnimal dono)
        {
            _contexto.DonosAnimais.Update(dono);
            _contexto.SaveChanges();
        }

        public void DeleteDono(DonoAnimal dono)
        {
            _contexto.DonosAnimais.Remove(dono);
            _contexto.SaveChanges();
        }
    }
}