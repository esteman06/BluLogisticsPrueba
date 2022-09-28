using BluLogistics.DataModel.Model;
using BluLogistics.Entitys;
using BluLogisticsService.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluLogisticsService.Services
{
    public class LibrosServices : ILibrosServices
    {
        private readonly BluLogisticsContext _context;
        public LibrosServices(BluLogisticsContext context)
        {
            _context = context;
        }
        public async Task<List<LibrosView>> GetAllLibors()
        {
            try
            {
                List<LibrosView> librosViews = new List<LibrosView>();
                var tempList = await _context.Libros.ToListAsync();
                if (tempList.Count > 0)
                {
                    foreach (Libros item in tempList)
                    {
                        LibrosView librosView = MapLibros(item);
                        librosViews.Add(librosView);
                    }
                }
                return librosViews.OrderBy(x => x.Titulo).ToList();
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
            return null;
        }

        public async Task<List<LibrosView>> GetLibrosByEditorialID(Guid editorialID)
        {
            try
            {
                List<LibrosView> librosViews = new List<LibrosView>();

                var tempList = await _context.Libros.Where(x => x.EditorialesID.Equals(editorialID)).ToListAsync();

                if (tempList.Count > 0)
                {
                    foreach (Libros item in tempList)
                    {
                        LibrosView libroViews = MapLibros(item);
                        librosViews.Add(libroViews);
                    }
                }
                return librosViews.OrderBy(x => x.Titulo).ToList();
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
            return null;
        }

        public async Task<List<LibrosView>> GetLibrosByLiborsID(Guid librosID)
        {
            try
            {
                List<LibrosView> librosViews = new List<LibrosView>();

                var tempList = await _context.Libros.Where(x => x.LibrosID.Equals(librosID)).ToListAsync();

                if (tempList.Count > 0)
                {
                    foreach (Libros item in tempList)
                    {
                        LibrosView libroViews = MapLibros(item);
                        librosViews.Add(libroViews);
                    }
                }
                return librosViews.OrderBy(x => x.Titulo).ToList();
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
            return null;
        }

        public async Task<int> CreateLibors(LibrosView librosView)
        {
            int result = 0;
            try
            {
                Libros libro = await _context.Libros.Where(x => x.Tittulo.Equals(librosView.Titulo)).FirstOrDefaultAsync();
                if (libro == null)
                {
                    result = 1;
                    Guid newGuid = Guid.NewGuid();
                    Libros newLibro = new Libros
                    {
                        LibrosID = newGuid,
                        EditorialesID = librosView.EditorialesID,
                        Tittulo = librosView.Titulo,
                        Sinopsis = librosView.Sinopsis,
                        NPaginas = librosView.NPaginas
                    };
                    _context.Libros.Add(newLibro);
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

        public async Task<int> UpdateLibors(LibrosView librosView)
        {
            int result = 0;
            try
            {
                var libro = await _context.Libros.Where(x => x.LibrosID.Equals(librosView.LibrosID)).FirstOrDefaultAsync();
                if (libro != null)
                {
                    var existsLibro = await _context.Libros.Where(x => x.Tittulo.ToUpper().Equals(librosView.Titulo.ToUpper())).FirstOrDefaultAsync();
                    if (existsLibro != null)
                    {
                        libro.EditorialesID = librosView.EditorialesID;
                        libro.Tittulo = librosView.Titulo;
                        libro.Sinopsis = librosView.Sinopsis;
                        libro.NPaginas = librosView.NPaginas;

                        _context.Entry(libro).State = EntityState.Modified;
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

        private LibrosView MapLibros(Libros libros)
        {
            LibrosView librosView = new LibrosView()
            {
                LibrosID = libros.LibrosID,
                EditorialesID = libros.EditorialesID,
                Titulo = libros.Tittulo,
                Sinopsis = libros.Sinopsis,
                NPaginas = libros.NPaginas
            };
            return librosView;
        }
    }
}
