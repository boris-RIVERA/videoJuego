using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
   
        [ApiController]
        [Route("[controller]")]
        public class UsuarioController : ControllerBase
        {
           
            private readonly ILogger<UsuarioController> _logger;
            private readonly AplicacionContexto _aplicacionContexto;
            public UsuarioController(
                ILogger<UsuarioController> logger,
                AplicacionContexto aplicacionContexto)
            {
                _logger = logger;
                _aplicacionContexto = aplicacionContexto;
            }
            //[HttpPost(Name = "CrearEstudiante")]
            [HttpPost]
            [Route("usuario")]
            public async Task<IActionResult> PostUsuario([FromBody] Usuario usuario)
            {
                _aplicacionContexto.Usuario.Add(usuario);
                _aplicacionContexto.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "creado");
            }


            // [HttpGet(Name = "GetEstudiante")]

            [HttpGet]
            [Route("")]
            public async Task<IActionResult> GetUsuario()
            {
                List<Usuario> listUsuario = _aplicacionContexto.Usuario.ToList();

                return StatusCode(StatusCodes.Status200OK, listUsuario);
            }

            //[HttpPut(Name = "PutEstudiante")]
            [HttpPut]
            [Route("EditarEstudiante/")]
            public async Task<IActionResult> EditUsuario([FromBody] Usuario Usuario)
            {
                _aplicacionContexto.Usuario.Update(Usuario);
                _aplicacionContexto.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "editado");


            }

            [HttpDelete]
            [Route("EliminarEstudiante/")]
            //[HttpDelete(Name = "DeleteEstudiante")]
            public async Task<IActionResult> DeleteUsuario(int? id)
            {
                Usuario usuario = _aplicacionContexto.Usuario.Find(id);
                _aplicacionContexto.Usuario.Remove( usuario);
                _aplicacionContexto.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "eliminado");
            }
        }
    
}
