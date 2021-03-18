using System.Collections.Generic;
using back._Models;

namespace back._Interfaces
{
    public interface IDonoAnimalRepository
    {
        DonoAnimal CreateDono (DonoAnimal dono);

        IEnumerable<DonoAnimal> donosAnimais { get; }

         void UpdateDono (DonoAnimal dono);         

         void DeleteDono (DonoAnimal dono);
    }
}