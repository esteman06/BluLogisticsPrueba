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
    public class AutoresService : IAutoresService
    {
        private readonly BluLogisticsContext _context;
        public AutoresService(BluLogisticsContext context)
        {
            _context = context;
        }
        public async Task<List<AutoresView>> GetAllAutores()
        {
            try
            {
                List<AutoresView> autoresViews = new List<AutoresView>();
                var tempList = await _context.Autores.ToListAsync();
                if (tempList.Count > 0)
                {
                    foreach (Autores item in tempList)
                    {
                        AutoresView autoresView = MapAutores(item);
                        autoresViews.Add(autoresView);
                    }
                }
                return autoresViews.OrderBy(x => x.Nombre).ThenBy(x => x.Apellidos).ToList();
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
            return null;
        }

        public async Task<AutoresView> GetAutoresByAutorID(Guid autorID)
        {
            try
            {
                AutoresView autoresView = new AutoresView();

                Autores temp = await _context.Autores.Where(x => x.AutoresID.Equals(autorID)).FirstOrDefaultAsync();

                if (temp != null)
                {
                    autoresView = MapAutores(temp);
                }
                return autoresView;
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
            return null;
        }
        //public async Task<List<AutoresView>> GetAutoresByEditorialID(Guid editorialID)
        //{
        //    try
        //    {
        //        List<AutoresView> autoresViews = new List<AutoresView>();

        //        var tempList = await _context.Autores
        //            .Join(_context.Autores_Has_Libros, a => a.AutoresID, ahl => ahl.AutoresID, (a, ahl) => new { a, ahl })
        //            .Join(_context.Libros, aa => aa.ahl.LibrosID, l => l.LibrosID, (aa, l) => new { aa, l })
        //            .Join(_context.Editoriales, ax => ax.l.EditorialesID, e => e.EditorialesID, (ax, e) => new { ax, e })
        //            .Where(x => x.e.EditorialesID.Equals(editorialID))
        //            .Select(x => new Autores{ AutoresID = x.ax.aa.a.AutoresID , Nombre = x.ax.aa.a.Nombre , Apellidos = x.ax.aa.a.Apellidos})
        //            .Distinct().ToListAsync();

        //        if (tempList.Count > 0)
        //        {
        //            foreach (Autores item in tempList)
        //            {
        //                AutoresView autoresView = MapAutores(item);
        //                autoresViews.Add(autoresView);
        //            }
        //        }
        //        return autoresViews.OrderBy(x => x.Nombre).ThenBy(x => x.Apellidos).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        var error = ex.ToString();
        //    }
        //    return null;
        //}

        public async Task<int> CreateAutores(AutoresView autoresView)
        {
            int result = 0;
            try
            {
                var existsAutor = await _context.Autores.Where(x => x.Nombre.ToUpper().Equals(autoresView.Nombre.ToUpper()) && x.Apellidos.ToUpper().Equals(autoresView.Apellidos.ToUpper())).FirstOrDefaultAsync();
                if (existsAutor == null)
                {
                    Guid newGuidAutor = Guid.NewGuid();
                    Autores newAutor = new Autores
                    {
                        AutoresID = newGuidAutor,
                        Nombre = autoresView.Nombre,
                        Apellidos = autoresView.Apellidos
                    };
                    _context.Autores.Add(newAutor);
                    await _context.SaveChangesAsync();

                    result = 1;
                    return result;
                }
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
            return result;
        }
        public async Task<int> UpdateAutores(AutoresView autoresView)
        {
            int result = 0;
            try
            {
                var autor = await _context.Autores.Where(x => x.AutoresID.Equals(autoresView.AutoresID)).FirstOrDefaultAsync();
                if (autor != null)
                {
                    var existsAutor = await _context.Autores.Where(x => x.Nombre.ToUpper().Equals(autoresView.Nombre.ToUpper()) && x.Apellidos.ToUpper().Equals(autoresView.Apellidos.ToUpper())).FirstOrDefaultAsync();
                    if (existsAutor == null)
                    {
                        autor.Nombre = autoresView.Nombre;
                        autor.Apellidos = autoresView.Apellidos;

                        _context.Entry(autor).State = EntityState.Modified;
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

        public async Task<int> DeleteAutores(Guid autorID)
        {
            int result = 0;
            try
            {
                var autor = await _context.Autores.Where(x => x.AutoresID.Equals(autorID)).FirstOrDefaultAsync();
                if (autor != null)
                {
                    _context.Autores.Remove(autor);
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
        private AutoresView MapAutores(Autores autores)
        {
            AutoresView autoresView = new AutoresView()
            {
                AutoresID = autores.AutoresID,
                Nombre = autores.Nombre,
                Apellidos = autores.Apellidos
            };
            return autoresView;
        }
    }
}
