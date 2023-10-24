using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Usuario
    {
        [Key]
        public int idusuario { get; set; }
        public string nombre { get; set; }
        public string genero { get; set; }
        public int edad { get; set; }
    }
}