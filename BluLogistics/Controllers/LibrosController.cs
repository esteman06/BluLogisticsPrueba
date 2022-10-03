using BluLogistics.DataModel.Model;
using BluLogistics.Entitys;
using BluLogisticsMVC.Helpers;
using BluLogisticsMVC.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluLogisticsMVC.Controllers
{
    public class LibrosController : Controller
    {
        private ILibrosServices _librosService;
        private readonly BluLogisticsContext _context;

        string response = null;
        public LibrosController(ILibrosServices librosService, BluLogisticsContext context)
        {
            _librosService = librosService;
            _context = context;
        }
        // GET: LibrosController
        public async Task<IActionResult> Index()
        {
            try
            {
                var librosView = await _librosService.GetAllLibors();
                if (librosView == null)
                {
                    response = Convert.ToString("No se ha encontrado ningún libro");
                    return NotFound(new EventMessage { Message = response });
                }
                return View(librosView);
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return BadRequest(new EventMessage { Message = "Error en el servicio GetAllLibors - Contacte al Adminsitrador" });
            }
        }

        // GET: LibrosController/Details/5
        public async Task<IActionResult> Details([FromRoute] Guid id)
        {
            try
            {
                var librosView = await _librosService.GetLibrosByLibroID(id);
                if (librosView == null)
                {
                    response = Convert.ToString("No se ha encontrado ningún Libro");
                    return NotFound(new EventMessage { Message = response });
                }
                return View(librosView);
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return BadRequest(new EventMessage { Message = "Error en el servicio GetLibrosByLibroID - Contacte al Adminsitrador" });
            }
        }

        // GET: LibrosController/Create
        public ActionResult Create()
        {
            var itemsEditoriales = new List<SelectListItem>();
            itemsEditoriales = _context.Editoriales.Select(c => new SelectListItem()
            {
                Text = c.Nombre,
                Value = c.EditorialesID.ToString()

            }).OrderBy(x => x.Text).ToList();
            ViewBag.Editoriales = itemsEditoriales;

            var itemsAutores = new List<SelectListItem>();
            itemsAutores = _context.Autores.Select(c => new SelectListItem()
            {
                Text = c.Nombre + " " + c.Apellidos,
                Value = c.AutoresID.ToString()

            }).OrderBy(x => x.Text).ToList();
            ViewBag.Autores = itemsAutores;

            return View();
        }

        // POST: LibrosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LibrosController/Edit/5
        public async Task<IActionResult> Edit([FromRoute]Guid id)
        {
            var itemsEditoriales = new List<SelectListItem>();
            itemsEditoriales = _context.Editoriales.Select(c => new SelectListItem()
            {
                Text = c.Nombre,
                Value = c.EditorialesID.ToString()

            }).OrderBy(x => x.Text).ToList();
            ViewBag.Editoriales = itemsEditoriales;

            var itemsAutores = new List<SelectListItem>();
            itemsAutores = _context.Autores.Select(c => new SelectListItem()
            {
                Text = c.Nombre + " " + c.Apellidos,
                Value = c.AutoresID.ToString()

            }).OrderBy(x => x.Text).ToList();
            ViewBag.Autores = itemsAutores;

            try
            {
                var librosView = await _librosService.GetLibrosByLibroID(id);
                if (librosView == null)
                {
                    response = Convert.ToString("No se ha encontrado ningún Libro");
                    return NotFound(new EventMessage { Message = response });
                }
                return View(librosView);
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return BadRequest(new EventMessage { Message = "Error en el servicio GetLibrosByLibroID - Contacte al Adminsitrador" });
            }
            return View();
        }

        // POST: LibrosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LibrosController/Delete/guid
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var librosView = await _librosService.GetLibrosByLibroID(id);
                if (librosView == null)
                {
                    response = Convert.ToString("No se ha encontrado ningún Libro");
                    return NotFound(new EventMessage { Message = response });
                }
                return View(librosView);
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return BadRequest(new EventMessage { Message = "Error en el servicio GetLibrosByLibroID - Contacte al Adminsitrador" });
            }
        }

        // POST: LibrosController/Delete/guid
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromRoute] Guid id)
        {
            try
            {
                try
                {
                    int result = await _librosService.DeleteLibro(id);
                    if (result == 0)
                    {
                        response = Convert.ToString("No se ha podido borrar el libro");
                        return NotFound(new EventMessage { Message = response });
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                    return BadRequest(new EventMessage { Message = "Error en el servicio DeleteLibro - Contacte al Adminsitrador" });
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
