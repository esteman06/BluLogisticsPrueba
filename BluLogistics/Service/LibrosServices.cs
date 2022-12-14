using BluLogistics.DataModel.Model;
using BluLogistics.Entitys;
using BluLogisticsMVC.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluLogisticsMVC.Services
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

        public async Task<LibrosView> GetLibrosByLibroID(Guid libroID)
        {
            try
            {
                LibrosView libroView = new LibrosView();

                var temp = await _context.Libros.Where(x => x.LibrosID.Equals(libroID)).FirstOrDefaultAsync();

                if (temp != null)
                {

                    libroView = MapLibros(temp);                    
                }
                return libroView;
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
            return null;
        }

        public async Task<List<LibrosView>> GetLibrosByAutorID(Guid AutorID)
        {
            try
            {
                List<LibrosView> librosViews = new List<LibrosView>();

                var tempList = await _context.Libros.Where(x => x.EditorialesID.Equals(AutorID)).ToListAsync();

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
        public async Task<int> CreateLibros(LibrosView librosView)
        {
            int result = 0;
            try
            {
                Libros libro = await _context.Libros.Where(x => x.Tittulo.Equals(librosView.Titulo)).FirstOrDefaultAsync();
                if (libro == null)
                {
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

                    Guid newGuidAutoresHasLibros = Guid.NewGuid();
                    Autores_has_libros newAutores_Has_Libros = new Autores_has_libros
                    {
                        Autores_has_librosID = newGuidAutoresHasLibros,
                        AutoresID = librosView.AutoresID,
                        LibrosID = newGuid
                    };

                    _context.Autores_Has_Libros.Add(newAutores_Has_Libros);
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

        public async Task<int> UpdateLibros(LibrosView librosView)
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

        public async Task<int> DeleteLibro(Guid libroID)
        {
            int result = 0;
            try
            {
                var libro = await _context.Libros.Where(x => x.LibrosID.Equals(libroID)).FirstOrDefaultAsync();
                if (libro != null)
                {
                    var autorHasLibro = await _context.Autores_Has_Libros.Where(x => x.LibrosID.Equals(libroID)).FirstOrDefaultAsync();
                    if (autorHasLibro != null) 
                    {
                        _context.Autores_Has_Libros.Remove(autorHasLibro);
                        await _context.SaveChangesAsync();

                        _context.Libros.Remove(libro);
                        await _context.SaveChangesAsync();
                    }
                    
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
        private LibrosView MapLibros(Libros libros)
        {
            Guid autorID = _context.Autores_Has_Libros.Where(x => x.LibrosID.Equals(libros.LibrosID)).Select(x => x.AutoresID).FirstOrDefault();
            LibrosView librosView = new LibrosView()
            {
                LibrosID = libros.LibrosID,
                EditorialesID = libros.EditorialesID,
                NombreEditorial = _context.Editoriales.Where(x => x.EditorialesID.Equals(libros.EditorialesID)).Select(x => x.Nombre).FirstOrDefault(),
                AutoresID = autorID,
                NombreAutor = _context.Autores.Where(x => x.AutoresID.Equals(autorID)).Select(x => x.Nombre+ " " + x.Apellidos).FirstOrDefault(),
                Titulo = libros.Tittulo,
                Sinopsis = libros.Sinopsis,
                NPaginas = libros.NPaginas
            };
            return librosView;
        }
    }
}
