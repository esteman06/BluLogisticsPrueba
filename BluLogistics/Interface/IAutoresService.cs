using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BluLogistics.Entitys;

namespace BluLogisticsMVC.Interfaces
{
    public interface IAutoresService
    {
        Task<List<AutoresView>> GetAllAutores();
        Task<List<AutoresView>> GetAutoresByEditorialID(Guid editorialID);
        Task<int> CreateAutores(AutoresView autoresView);
        Task<int> UpdateAutores(AutoresView autoresView);
    }
}
