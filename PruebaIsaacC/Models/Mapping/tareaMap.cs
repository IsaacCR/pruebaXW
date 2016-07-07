using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PruebaIsaacC.Models.Mapping
{
    public class tareaMap : EntityTypeConfiguration<tarea>
    {
        public tareaMap()
        {
            // Primary Key
            this.HasKey(t => t.idTarea);

            // Properties
            // Table & Column Mappings
            this.ToTable("tarea", "mydb");
            this.Property(t => t.idTarea).HasColumnName("idTarea");
            this.Property(t => t.Nota).HasColumnName("Nota");
            this.Property(t => t.Curso_idCurso).HasColumnName("Curso_idCurso");

            // Relationships
            this.HasRequired(t => t.curso)
                .WithMany(t => t.tareas)
                .HasForeignKey(d => d.Curso_idCurso);

        }
    }
}
