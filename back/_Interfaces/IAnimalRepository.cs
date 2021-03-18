using System.Collections.Generic;
using back._Models;

namespace back._Interfaces
{
    public interface IAnimalRepository
    {

        Animal CreateAnimal (Animal animal);

         IEnumerable<Animal> animais { get; }

         void UpdateAnimal (Animal animal);

         void DeleteAnimal (Animal animal);
    }
}