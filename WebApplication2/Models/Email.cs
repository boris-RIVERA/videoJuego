using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Email
    {
        [Key]
        public int idemail { get; set; }
        public string email { get; set; }

        [ForeignKey("email")]
        public int idusuario { get; set; }
        
    }
}