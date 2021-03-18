using System.Collections.Generic;
using System.Linq;
using back._Data;
using back._Interfaces;
using back._Models;
using Microsoft.AspNetCore.Mvc;

namespace back._Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _contexto;

        public AnimalController(IAnimalRepository contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Animal> List (){
            return _contexto.animais;
        }

        [HttpGet("{Id}")]
        public Animal GetById (int Id) {
            return _contexto.animais.FirstOrDefault(a => a.Id == Id);
        } 
        [HttpGet("Nome")]
        public Animal GetByNome (string Nome) {
            return _contexto.animais.FirstOrDefault(a => a.Nome.ToLower() == Nome.ToLower());
        } 
        
        [HttpPut("{Animal}")]
        public bool UpdateAnimal (Animal animal) {
            if (animal == null) return false; 

            try {
                Animal _animal = GetById(animal.Id);
                if (_animal.Id != animal.Id) return false;
                
                _animal.Nome = animal.Nome;
                _animal.Dono = animal.Dono;
                _animal.MotivoInternacao = animal.MotivoInternacao;
                _animal.EstadoSaude = animal.EstadoSaude;
                _animal.Foto = animal.Foto;
                _contexto.UpdateAnimal(_animal);
                
                return true;
            } catch {
                return false;
            }
        }

        [HttpPost("{Animal}")]
        public void CreateAnimal (Animal animal) {
            if (animal == null) return;

            _contexto.CreateAnimal(animal);
        }

        [HttpDelete("{Id}")]
        public void DeleteAnimalById (int id) {
            Animal animal = GetById(id);
            if (animal.Id != id) return;

            _contexto.DeleteAnimal(animal);

        }
    }
}