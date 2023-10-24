using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class VideoJuego
    {
        [Key]
        public int idVideoJuego { get; set; }
        public string Nombre { get; set; }
        public string TipoDePago { get; set; }
        public Boolean EsGrupal { get; set; }
        public string tipo { get; set; }

        [ForeignKey("usuario")]
        public int idUsuario { get; set; }
        public Usuario usuario { get; set; }
    }
}