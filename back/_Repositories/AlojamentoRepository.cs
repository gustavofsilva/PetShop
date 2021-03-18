using System.Collections.Generic;
using back._Data;
using back._Interfaces;
using back._Models;
using Microsoft.EntityFrameworkCore;

namespace back._Repositories
{
    public class AlojamentoRepository : IAlojamentoRepository
    {
        private readonly PetShopContext _contexto;

        public AlojamentoRepository(PetShopContext contexto)
        {
            _contexto = contexto;
        }

        public Alojamento CreateAlojamento(Alojamento alojamento)
        {
            _contexto.Alojamentos.Add(alojamento);
            _contexto.SaveChanges();
            return alojamento;
        }
        
        public IEnumerable<Alojamento> alojamentos => _contexto.Alojamentos.Include(alojamento => alojamento.Animal).ThenInclude(animal => animal.Dono);

        public void UpdateAlojamento(Alojamento alojamento)
        {
            _contexto.Alojamentos.Update(alojamento);            
            _contexto.SaveChanges();
        }        

        public void DeleteAlojamento(Alojamento alojamento)
        {
            _contexto.Remove(alojamento);
            _contexto.SaveChanges();
        }    
        
    }
}