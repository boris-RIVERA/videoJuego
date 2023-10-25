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
           
            private readonly ILogger<EmailController> _logger;
            private readonly AplicacionContexto _aplicacionContexto;
            public EmailController(
                ILogger<EmailController> logger,
                AplicacionContexto aplicacionContexto)
            {
                _logger = logger;
                _aplicacionContexto = aplicacionContexto;
            }
            //[HttpPost(Name = "CrearEstudiante")]
            [HttpPost]
            [Route("Email")]
            public async Task<IActionResult> PostEmail([FromBody] Email email)
            {
                _aplicacionContexto.Email.Add(  email);
                _aplicacionContexto.SaveChanges();
                return Ok(email);
            }


            // [HttpGet(Name = "GetEstudiante")]

            [HttpGet]
            [Route("")]
            public async Task<IActionResult> GetEmail()
            {
                List<Email> listEmail = _aplicacionContexto.Email.ToList();

                return StatusCode(StatusCodes.Status200OK, listEmail);
            }

            //[HttpPut(Name = "PutEstudiante")]
            [HttpPut]
            [Route("EditarEstudiante/")]
            public async Task<IActionResult> EditEmail([FromBody] Email Email)
            {
                _aplicacionContexto.Email.Update(Email);
                _aplicacionContexto.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "editado");


            }

            [HttpDelete]
            [Route("EliminarEstudiante/")]
            //[HttpDelete(Name = "DeleteEstudiante")]
            public async Task<IActionResult> DeleteEmail(int? id)
            {
                Email Email = _aplicacionContexto.Email.Find(id);
                _aplicacionContexto.Email.Remove( Email);
                _aplicacionContexto.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "eliminado");
            }
        }
    
}
