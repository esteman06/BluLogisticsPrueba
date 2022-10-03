using BluLogistics.Entitys;
using BluLogisticsMVC.Helpers;
using BluLogisticsMVC.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BluLogisticsMVC.Controllers
{
    public class AutoresController : Controller
    {
        private IAutoresService _autoresService;
        string response = null;
        public AutoresController(IAutoresService autoresService)
        {
            _autoresService = autoresService;
        }
        // GET: AutoresController
        public async Task<IActionResult> Index()
        {
            try
            {
                var autoresView = await _autoresService.GetAllAutores();
                if (autoresView == null)
                {
                    response = Convert.ToString("No se ha encontrado ningúna editorial");
                    return NotFound(new EventMessage { Message = response });
                }
                return View(autoresView);
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return BadRequest(new EventMessage { Message = "Error en el servicio GetAllAutores - Contacte al Adminsitrador" });
            }
        }

        //GET: autoresController/Details/guid
        public async Task<IActionResult> Details([FromRoute] Guid id)
        {
            try
            {
                var autoresView = await _autoresService.GetAutoresByAutorID(id);
                if (autoresView == null)
                {
                    response = Convert.ToString("No se ha encontrado ningún Autor");
                    return NotFound(new EventMessage { Message = response });
                }
                return View(autoresView);
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return BadRequest(new EventMessage { Message = "Error en el servicio GetAutoresByAutorID - Contacte al Adminsitrador" });
            }
        }

        // GET: autoresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: autoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Nombre,Apellidos")] AutoresView autoresView)
        {
            try
            {
                try
                {
                    int result = await _autoresService.CreateAutores(autoresView);
                    if (result == 0)
                    {
                        response = Convert.ToString("No se ha podido crear el Autor");
                        return NotFound(new EventMessage { Message = response });
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                    return BadRequest(new EventMessage { Message = "Error en el servicio CreateAutores - Contacte al Adminsitrador" });
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: autoresController/Edit/guid
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            try
            {
                var autoresView = await _autoresService.GetAutoresByAutorID(id);
                if (autoresView == null)
                {
                    response = Convert.ToString("No se ha encontrado ningún Autor");
                    return NotFound(new EventMessage { Message = response });
                }
                return View(autoresView);
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return BadRequest(new EventMessage { Message = "Error en el servicio GetAutoresByAutorID - Contacte al Adminsitrador" });
            }
        }

        // POST: autoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("AutoresID,Nombre,Apellidos")] AutoresView autoresView)
        {
            try
            {
                try
                {
                    int result = await _autoresService.UpdateAutores(autoresView);
                    if (result == 0)
                    {
                        response = Convert.ToString("No se ha podido modificar el Autor");
                        return NotFound(new EventMessage { Message = response });
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                    return BadRequest(new EventMessage { Message = "Error en el servicio UpdateAutores - Contacte al Adminsitrador" });
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: autoresController/Delete/5
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var autoresView = await _autoresService.GetAutoresByAutorID(id);
                if (autoresView == null)
                {
                    response = Convert.ToString("No se ha encontrado ningún Autor");
                    return NotFound(new EventMessage { Message = response });
                }
                return View(autoresView);
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return BadRequest(new EventMessage { Message = "Error en el servicio GetAutoresByAutorID - Contacte al Adminsitrador" });
            }
        }

        // POST: autoresController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromRoute] Guid id)
        {
            try
            {
                try
                {
                    int result = await _autoresService.DeleteAutores(id);
                    if (result == 0)
                    {
                        response = Convert.ToString("No se ha podido borrar el autor");
                        return NotFound(new EventMessage { Message = response });
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                    return BadRequest(new EventMessage { Message = "Error en el servicio DeleteAutores - Contacte al Adminsitrador" });
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
