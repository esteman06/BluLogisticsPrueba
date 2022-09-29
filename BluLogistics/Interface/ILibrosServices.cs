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
        Task<List<LibrosView>> GetLibrosByLiborsID(Guid liborsID);
        Task<int> CreateLibors(LibrosView librosView);
        Task<int> UpdateLibors(LibrosView librosView);
    }
}
