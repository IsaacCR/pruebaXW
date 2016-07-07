using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PruebaIsaacC.Models.Mapping;

namespace PruebaIsaacC.Models
{
    public partial class mydbContext : DbContext
    {
        static mydbContext()
        {
            Database.SetInitializer<mydbContext>(null);
        }

        public mydbContext()
            : base("Name=mydbContext")
        {
        }

        public DbSet<asignacion> asignacions { get; set; }
        public DbSet<curso> cursoes { get; set; }
        public DbSet<estudiante> estudiantes { get; set; }
        public DbSet<tarea> tareas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new asignacionMap());
            modelBuilder.Configurations.Add(new cursoMap());
            modelBuilder.Configurations.Add(new estudianteMap());
            modelBuilder.Configurations.Add(new tareaMap());
        }
    }
}
