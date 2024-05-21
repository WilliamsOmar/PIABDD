using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Data;
using System.Data.SqlClient;

using PiaBD.Data;
using PiaBD.Models;

namespace PiaBD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiaController : ControllerBase
    {
        private readonly PropiedadesData _propiedadesData;

        public PiaController(PropiedadesData propiedadesData)
        {
            _propiedadesData = propiedadesData;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Propiedad> Lista = await _propiedadesData.Lista();
            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            Propiedad objeto = await _propiedadesData.Obtener(id);
            return StatusCode(StatusCodes.Status200OK, objeto);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Propiedad objeto)
        {
            bool respuesta = await _propiedadesData.Crear(objeto);
            return StatusCode(StatusCodes.Status200OK, new {isSuccess = respuesta});
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] Propiedad objeto)
        {
            bool respuesta = await _propiedadesData.Editar(objeto);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool respuesta = await _propiedadesData.Eliminar(id);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }
    }
}
