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
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<UsuarioController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public UsuarioController(
            ILogger<UsuarioController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //[HttpPost(Name = "CrearUsuario")]
        [HttpPost]
        [Route("usuario")]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            _aplicacionContexto.usuario.AllAsync(usuario);
            _aplicacionContexto.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "creado");
        }


        // [HttpGet(Name = "GetEstudiante")]

        [HttpGet]
        [Route("MostrarEstudiante")]
        public async Task<IActionResult> Get()
        {
            List<VideoJuego> listUsuario = _aplicacionContexto.usuario.OrderByDescending(Usuario => Usuario.ReferenceEquals)
                .ToList();

            return StatusCode(StatusCodes.Status200OK, listUsuario);
        }

        //[HttpPut(Name = "PutEstudiante")]
        [HttpPut]
        [Route("EditarEstudiante/")]
        public async Task<IActionResult> Edit([FromBody] Usuario usuario)
        {
            _aplicacionContexto.usuario.Update(usuario);
            _aplicacionContexto.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "editado");


        }

        [HttpDelete]
        [Route("EliminarEstudiante/")]
        //[HttpDelete(Name = "DeleteEstudiante")]
        public async Task<IActionResult> Delete(int? id)
        {
            Usuario usuario = _aplicacionContexto.usuario.Find(id);
            _aplicacionContexto.usuario.Remove(usuario);
            _aplicacionContexto.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "eliminado");
        }
    }
}