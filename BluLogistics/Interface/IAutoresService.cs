using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BluLogistics.Entitys;

namespace BluLogisticsMVC.Interfaces
{
    public interface IAutoresService
    {
        Task<List<AutoresView>> GetAllAutores();
        Task<AutoresView> GetAutoresByAutorID(Guid autorID);
        Task<int> CreateAutores(AutoresView autoresView);
        Task<int> UpdateAutores(AutoresView autoresView);
        Task<int> DeleteAutores(Guid autorID);
    }
}
