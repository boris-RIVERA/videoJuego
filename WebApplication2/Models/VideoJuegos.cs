using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class VideoJuegos
    {
        [Key]
        public int idvideojuego { get; set; }
        public string nombre { get; set; }
        public string tipodepago { get; set; }
        public Boolean esgrupal { get; set; }
        public string tipo { get; set; }

        [ForeignKey("VideoJuego")]
        public int idusuario { get; set; }
        
    }
}