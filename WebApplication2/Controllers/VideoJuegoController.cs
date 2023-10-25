using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
   
        [ApiController]
        [Route("[controller]")]
        public class VideoJuegoController : ControllerBase
        {
           
            private readonly ILogger<VideoJuegoController> _logger;
            private readonly AplicacionContexto _aplicacionContexto;
            public VideoJuegoController(
                ILogger<VideoJuegoController> logger,
                AplicacionContexto aplicacionContexto)
            {
                _logger = logger;
                _aplicacionContexto = aplicacionContexto;
            }
            //[HttpPost(Name = "CrearEstudiante")]
            [HttpPost]
            [Route("VideoJuego")]
            public async Task<IActionResult> PostVideoJuego([FromBody] VideoJuegos VideoJuegos)
            {
                _aplicacionContexto.VideoJuegos.Add(VideoJuegos);
                _aplicacionContexto.SaveChanges();
                return Ok(VideoJuegos);
            }


            // [HttpGet(Name = "GetEstudiante")]

            [HttpGet]
            [Route("")]
            public async Task<IActionResult> GetVideoJuego()
            {
                List<VideoJuegos> listVideoJuego = _aplicacionContexto.VideoJuegos.ToList();

                return StatusCode(StatusCodes.Status200OK, listVideoJuego);
            }

            //[HttpPut(Name = "PutEstudiante")]
            [HttpPut]
            [Route("EditarVideoJuego/")]
            public async Task<IActionResult> EditVideoJuego([FromBody] VideoJuegos VideoJuegos)
            {
                _aplicacionContexto.VideoJuegos.Update(VideoJuegos);
                _aplicacionContexto.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "editado");


            }

            [HttpDelete]
            [Route("EliminarVideoJuego/")]
            //[HttpDelete(Name = "DeleteEstudiante")]
            public async Task<IActionResult> DeleteVideoJuego(int? id)
            {
                VideoJuegos VideoJuegos = _aplicacionContexto.VideoJuegos.Find(id);
                _aplicacionContexto.VideoJuegos.Remove( VideoJuegos);
                _aplicacionContexto.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "eliminado");
            }
        }
    
}
