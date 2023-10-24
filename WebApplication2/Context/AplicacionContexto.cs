using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Context
{
    public class AplicacionContexto : DbContext
    {
        public AplicacionContexto
            (DbContextOptions<AplicacionContexto> options)
            : base(options) { }

        public DbSet<Usuario> Usuario{ get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<VideoJuego> VideoJuego { get; set; }


    }
}
