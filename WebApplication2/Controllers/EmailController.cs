using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<EmailController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public EmailController(
            ILogger<EmailController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //[HttpPost(Name = "CrearUsuario")]
        [HttpPost]
        [Route("email")]
        public async Task<IActionResult> Post([FromBody] Email email)
        {
            _aplicacionContexto.email.AllAsync(email);
            _aplicacionContexto.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "creado");
        }


        // [HttpGet(Name = "GetEstudiante")]

        [HttpGet]
        [Route("MostrarEstudiante")]
        public async Task<IActionResult> Get()
        {
            List<VideoJuego> listEmail = _aplicacionContexto.usuario.OrderByDescending(Email => Email.ReferenceEquals)
                .ToList();

            return StatusCode(StatusCodes.Status200OK, listEmail);
        }

        //[HttpPut(Name = "PutEstudiante")]
        [HttpPut]
        [Route("EditarEstudiante/")]
        public async Task<IActionResult> Edit([FromBody] Email email)
        {
            _aplicacionContexto.email.Update(email);
            _aplicacionContexto.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "editado");


        }

        [HttpDelete]
        [Route("EliminarEstudiante/")]
        //[HttpDelete(Name = "DeleteEstudiante")]
        public async Task<IActionResult> Delete(int? id)
        {
            Email  email = _aplicacionContexto.email.Find(id);
            _aplicacionContexto.email.Remove(email);
            _aplicacionContexto.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "eliminado");
        }
    }
}