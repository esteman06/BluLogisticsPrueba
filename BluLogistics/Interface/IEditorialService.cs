using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BluLogistics.Entitys;

namespace BluLogisticsMVC.Interfaces
{
    public interface IEditorialService
    {
        Task<List<EditorialesView>> GetAllEditoriales();
        Task<EditorialesView> GetEditorialesByEditorialID(Guid editorialID);
        Task<int> CreateEditorial(EditorialesView editorialesView);       
        Task<int> UpdateEditoriales(EditorialesView editorialesView);
    }
}
