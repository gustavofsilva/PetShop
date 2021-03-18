using System.Collections.Generic;
using back._Models;

namespace back._Interfaces
{
    public interface IAlojamentoRepository
    {
        Alojamento CreateAlojamento (Alojamento alojamento);

        IEnumerable<Alojamento> alojamentos { get; }

        void UpdateAlojamento (Alojamento alojamento);   

        void DeleteAlojamento(Alojamento alojamento);

        
         
    }
}