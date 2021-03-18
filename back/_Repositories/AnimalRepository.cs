using System.Collections.Generic;
using back._Data;
using back._Interfaces;
using back._Models;
using Microsoft.EntityFrameworkCore;

namespace back._Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly PetShopContext _contexto;

        public AnimalRepository(PetShopContext contexto)
        {
            _contexto = contexto;
        }        

        public Animal CreateAnimal(Animal animal)
        {            
            _contexto.Animais.Add(animal);
            _contexto.SaveChanges();       
            return animal; 
        }
        public IEnumerable<Animal> animais => _contexto.Animais.Include(animal => animal.Dono);

        public void UpdateAnimal(Animal novoAnimal)
        {
            _contexto.Animais.Update(novoAnimal);
            _contexto.SaveChanges();
        }
        public void DeleteAnimal(Animal animal)
        {
            _contexto.Animais.Remove(animal);
            _contexto.SaveChanges();
        }
        
    }
}