using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BluLogistics.Entitys;
using BluLogisticsService.Helpers;
using BluLogisticsService.Interfaces;

namespace BluLogisticsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialesController : ControllerBase
    {
        private IEditorialService _editorialService;
        string response = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="EditorialService"></param>
        public EditorialesController(IEditorialService editorialService)
        {
            _editorialService = editorialService;
        }

        /// <summary>
        /// Get All Editoriales
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(EventMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(EventMessage), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAllEditoriales()
        {
            try
            {
                var autoresView = await _editorialService.GetAllEditoriales();
                if (autoresView == null)
                {
                    response = Convert.ToString("No se ha encontrado ningúna editorial");
                    return NotFound(new EventMessage { Message = response });
                }
                return Ok(autoresView);
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return BadRequest(new EventMessage { Message = "Error en el servicio GetAllEditoriales - Contacte al Adminsitrador" });
            }
        }

        /// <summary>
        /// Create a new Editorial
        /// </summary>
        /// <param name="editorialesView">vista editorial</param>
        /// <returns></returns>
        [HttpPost("CreateEditorial")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(EventMessage), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateEditorial([FromBody] EditorialesView editorialesView)
        {
            try
            {
                int result = await _editorialService.CreateEditorial(editorialesView);
                if (result == 0)
                {
                    response = Convert.ToString("No se ha podido crear la editorial");
                    return NotFound(new EventMessage { Message = response });
                }
                return Ok();
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return BadRequest(new EventMessage { Message = "Error en el servicio CreateEditorial - Contacte al Adminsitrador" });
            }
        }
    }
}
