using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PruebaIsaacC.Models.Mapping
{
    public class estudianteMap : EntityTypeConfiguration<estudiante>
    {
        public estudianteMap()
        {
            // Primary Key
            this.HasKey(t => t.idEstudiante);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("estudiante", "mydb");
            this.Property(t => t.idEstudiante).HasColumnName("idEstudiante");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
        }
    }
}
