using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BluLogistics.DataModel.Model;
using BluLogistics.Entitys;
using BluLogisticsMVC.Interfaces;

namespace BluLogisticsMVC.Services
{
    public class EditorialService : IEditorialService
    {
        private readonly BluLogisticsContext _context;
        public EditorialService(BluLogisticsContext context)
        {
            _context = context;
        }

        public async Task<List<EditorialesView>> GetAllEditoriales()
        {
            try
            {
                List<EditorialesView>editorialesViews = new List<EditorialesView>();
                var tempList = await _context.Editoriales.ToListAsync();
                if (tempList.Count > 0)
                {
                    foreach (Editoriales item in tempList)
                    {
                        EditorialesView editorialesView = MapEditoriales(item);
                        editorialesViews.Add(editorialesView);
                    }
                }
                return editorialesViews.OrderBy(x => x.Nombre).ToList();
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
            return null;
        }

        public async Task<EditorialesView> GetEditorialesByEditorialID(Guid editorialID)
        {
            try
            {
                EditorialesView EditorialView = new EditorialesView();

                Editoriales temp = await _context.Editoriales.Where(x => x.EditorialesID.Equals(editorialID)).FirstOrDefaultAsync();

                if (temp != null)
                {
                    EditorialView = MapEditoriales(temp);
                }
                return EditorialView;
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
            return null;
        }

        public async Task<int> CreateEditorial(EditorialesView editorialesView)
        {
            int result = 0;
            try
            {
                Editoriales editoriales = await _context.Editoriales.Where(x => x.Nombre.Equals(editorialesView.Nombre)).FirstOrDefaultAsync();
                if (editoriales == null)
                {
                    result = 1;
                    Guid newGuid = Guid.NewGuid();
                    Editoriales newEditorial = new Editoriales
                    {
                        EditorialesID = newGuid,
                        Nombre = editorialesView.Nombre,
                        Sede = editorialesView.Sede
                    };
                    _context.Editoriales.Add(newEditorial);
                    await _context.SaveChangesAsync();

                    return result;
                }
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
            return result;
        }

        public async Task<int> UpdateEditoriales(EditorialesView editorialesView)
        {
            int result = 0;
            try
            {
                var editorial = await _context.Editoriales.Where(x => x.EditorialesID.Equals(editorialesView.EditorialesID)).FirstOrDefaultAsync();
                if (editorial != null)
                {
                    var existsEditorial = await _context.Editoriales.Where(x => x.Nombre.ToUpper().Equals(editorialesView.Nombre.ToUpper()) && x.Sede.ToUpper().Equals(editorialesView.Sede.ToUpper())).FirstOrDefaultAsync();
                    if (existsEditorial == null)
                    {
                        editorial.Nombre = editorialesView.Nombre;
                        editorial.Sede = editorialesView.Sede;

                        _context.Entry(editorial).State = EntityState.Modified;
                        await _context.SaveChangesAsync();

                        result = 1;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
            return result;
        }

        public async Task<int> DeleteEditoriales(Guid editorialesID)
        {
            int result = 0;
            try
            {
                var editorial = await _context.Editoriales.Where(x => x.EditorialesID.Equals(editorialesID)).FirstOrDefaultAsync();
                if (editorial != null)
                {
                    _context.Editoriales.Remove(editorial);
                    await _context.SaveChangesAsync();
                    result = 1;
                }
                return result;
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
            return result;
        }
        private EditorialesView MapEditoriales(Editoriales editoriales)
        {
            EditorialesView editorialesView = new EditorialesView()
            {
                EditorialesID = editoriales.EditorialesID,
                Nombre = editoriales.Nombre,
                Sede = editoriales.Sede
            };
            return editorialesView;
        }
    }
}
