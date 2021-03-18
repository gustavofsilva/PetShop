using System;
using System.Collections.Generic;
using System.Linq;
using back._Interfaces;
using back._Models;
using Microsoft.AspNetCore.Mvc;

namespace back._Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlojamentoController : ControllerBase
    {
        private readonly IAlojamentoRepository _contexto;

        public AlojamentoController(IAlojamentoRepository contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Alojamento> List (){
            return _contexto.alojamentos;
        }

        [HttpPut("{Alojamento}")]
        public bool UpdateAlojamento(Alojamento alojamento) {
             if (alojamento == null) return false; 

            try {                

                _contexto.UpdateAlojamento(alojamento);
                
                return true;
            } catch {
                return false;
            }
        }

        [HttpGet("{Id}")]
        public Alojamento GetById (int Id) {
            return _contexto.alojamentos.FirstOrDefault(p => p.Id == Id);
        }

        [HttpDelete("{Id}")]
        public bool DeleteById (int Id) {
            try {

                Alojamento _alojamento = GetById (Id);
                if (_alojamento.Id != Id) return false;
                
                _contexto.DeleteAlojamento(_alojamento);
                
                return true;
            } catch {
                return false;
            }
        }

        [HttpPost("{Alojamento}")]
        public void CreateAlojamento (Alojamento alojamento) {
            if (alojamento == null) return;

            _contexto.CreateAlojamento(alojamento);
        }
    }
}