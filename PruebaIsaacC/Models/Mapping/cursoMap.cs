using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PruebaIsaacC.Models.Mapping
{
    public class cursoMap : EntityTypeConfiguration<curso>
    {
        public cursoMap()
        {
            // Primary Key
            this.HasKey(t => t.idCurso);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("curso", "mydb");
            this.Property(t => t.idCurso).HasColumnName("idCurso");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
        }
    }
}
