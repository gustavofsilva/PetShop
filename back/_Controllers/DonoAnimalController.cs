using System.Collections.Generic;
using System.Linq;
using back._Interfaces;
using back._Models;
using Microsoft.AspNetCore.Mvc;

namespace back._Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonoAnimalController : ControllerBase
    {
        private readonly IDonoAnimalRepository _contexto;

        public DonoAnimalController(IDonoAnimalRepository contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<DonoAnimal> List (){
            return _contexto.donosAnimais;
        }

        [HttpGet("{Id}")]
        public DonoAnimal GetById (int Id) {
            return _contexto.donosAnimais.FirstOrDefault(p => p.Id == Id);
        } 

        [HttpPut("{donoAnimal}")] 
        public bool Update (DonoAnimal donoAnimal) {
            if (donoAnimal == null) return false;
            try {
                DonoAnimal _donoAnimal = GetById(donoAnimal.Id);
                if (_donoAnimal.Id != donoAnimal.Id) return false;

                _donoAnimal.Nome = donoAnimal.Nome;
                _donoAnimal.Endereco = donoAnimal.Endereco;
                _donoAnimal.Telefone = donoAnimal.Telefone;
                _contexto.UpdateDono(_donoAnimal);
                return true;
            } catch {
                return false;
            }
        }

        [HttpDelete("{id}")]
        public bool DeleteDonoAnimal(int id){
            try {
                DonoAnimal dono = GetById(id);
                if (dono.Id == id && dono != null) {
                    _contexto.DeleteDono(dono);
                }
                return true;
            } catch {
                return false;
            }
        }

        [HttpPost("{DonoAnimal}")]
        public void  CreateDonoAnimal (DonoAnimal dono) {
            if (dono == null) return;

            _contexto.CreateDono(dono);
        }
    }
}