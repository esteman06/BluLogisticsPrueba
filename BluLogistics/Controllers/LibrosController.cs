using BluLogisticsMVC.Helpers;
using BluLogisticsMVC.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BluLogisticsMVC.Controllers
{
    public class LibrosController : Controller
    {
        private ILibrosServices _librosService;
        string response = null;
        public LibrosController(ILibrosServices librosService)
        {
            _librosService = librosService;
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
        public ActionResult Edit(int id)
        {
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
