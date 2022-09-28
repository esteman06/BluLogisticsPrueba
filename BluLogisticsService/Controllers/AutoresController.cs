using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BluLogisticsService.Helpers;
using BluLogisticsService.Interfaces;

namespace BluLogisticsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private IAutoresService _autoresService;
        string response = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="AutoresService"></param>
        public AutoresController(IAutoresService autoresService)
        {
            _autoresService = autoresService;
        }

        /// <summary>
        /// Get All Autores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(EventMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(EventMessage), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAllAutores()
        {
            try
            {
                var autoresView = await _autoresService.GetAllAutores();
                if (autoresView == null)
                {
                    response = Convert.ToString("No se ha encontrado ningún Autor");
                    return NotFound(new EventMessage { Message = response });
                }
                return Ok(autoresView);
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return BadRequest(new EventMessage { Message = "Error en el servicio GetAllAutores - Contacte al Adminsitrador" });
            }
        }

        /// <summary>
        /// Get Autores by editorialID
        /// </summary>
        /// <param name="editorialID">Guid de la editorial</param>
        /// <returns></returns>
        [HttpGet("GetAutoresByEditorialID/{editorialID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(EventMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(EventMessage), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAutoresByEditorialID([FromRoute] Guid editorialID)
        {
            try
            {
                var autoresView = await _autoresService.GetAutoresByEditorialID(editorialID);
                if (autoresView == null)
                {
                    response = Convert.ToString("No se ha encontrado ningún Autor");
                    return NotFound(new EventMessage { Message = response });
                }
                return Ok(autoresView);
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return BadRequest(new EventMessage { Message = "Error en el servicio GetAutoresByEditorialID - Contacte al Adminsitrador" });
            }
        }
    }
}
