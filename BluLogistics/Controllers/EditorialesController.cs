using BluLogistics.Entitys;
using BluLogisticsMVC.Helpers;
using BluLogisticsMVC.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BluLogisticsMVC.Controllers
{
    public class EditorialesController : Controller
    {
        private IEditorialService _editorialService;
        string response = null;
        public EditorialesController(IEditorialService editorialService)
        {
            _editorialService = editorialService;
        }
        // GET: EditorialesController
        public async Task<IActionResult> Index()
        {
            try
            {
                var editorialesView = await _editorialService.GetAllEditoriales();
                if (editorialesView == null)
                {
                    response = Convert.ToString("No se ha encontrado ningúna editorial");
                    return NotFound(new EventMessage { Message = response });
                }
                return View(editorialesView);
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return BadRequest(new EventMessage { Message = "Error en el servicio GetAllEditoriales - Contacte al Adminsitrador" });
            }
        }

        //GET: EditorialesController/Details/guid
        public async Task<ActionResult> Details(Guid editorialID)
        {
            try
            {
                var editorialesView = await _editorialService.GetEditorialesByEditorialID(editorialID);
                if (editorialesView == null)
                {
                    response = Convert.ToString("No se ha encontrado ningún Autor");
                    return NotFound(new EventMessage { Message = response });
                }
                return View(editorialesView);
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return BadRequest(new EventMessage { Message = "Error en el servicio GetEditorialesByEditorialID - Contacte al Adminsitrador" });
            }
        }

        // GET: EditorialesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EditorialesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Nombre,Sede")] EditorialesView editorialesView)
        {
            try
            {
                try
                {
                    int result = await _editorialService.CreateEditorial(editorialesView);
                    if (result == 0)
                    {
                        response = Convert.ToString("No se ha podido crear la editorial");
                        return NotFound(new EventMessage { Message = response });
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                    return BadRequest(new EventMessage { Message = "Error en el servicio CreateEditorial - Contacte al Adminsitrador" });
                }
            }
            catch
            {
                return View();
            }
        }

        //// GET: EditorialesController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: EditorialesController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: EditorialesController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: EditorialesController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
