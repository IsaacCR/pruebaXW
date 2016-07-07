using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PruebaIsaacC.Models.Mapping
{
    public class asignacionMap : EntityTypeConfiguration<asignacion>
    {
        public asignacionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Estudiante_idEstudiante, t.Curso_idCurso });

            // Properties
            this.Property(t => t.Estudiante_idEstudiante)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Curso_idCurso)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("asignacion", "mydb");
            this.Property(t => t.Estudiante_idEstudiante).HasColumnName("Estudiante_idEstudiante");
            this.Property(t => t.Curso_idCurso).HasColumnName("Curso_idCurso");
            this.Property(t => t.NotaFinal).HasColumnName("NotaFinal");

            // Relationships
            this.HasRequired(t => t.curso)
                .WithMany(t => t.asignacions)
                .HasForeignKey(d => d.Curso_idCurso);
            this.HasRequired(t => t.estudiante)
                .WithMany(t => t.asignacions)
                .HasForeignKey(d => d.Estudiante_idEstudiante);

        }
    }
}
