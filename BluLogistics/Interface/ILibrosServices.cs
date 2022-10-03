using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BluLogistics.Entitys;

namespace BluLogisticsMVC.Interfaces
{
    public interface ILibrosServices
    {
        Task<List<LibrosView>> GetAllLibors();
        Task<List<LibrosView>> GetLibrosByEditorialID(Guid editorialID);
        Task<LibrosView> GetLibrosByLibroID(Guid libroID);
        Task<List<LibrosView>> GetLibrosByAutorID(Guid autorID);
        Task<int> CreateLibros(LibrosView librosView);
        Task<int> UpdateLibros(LibrosView librosView);
        Task<int> DeleteLibro(Guid libroID);
    }
}
