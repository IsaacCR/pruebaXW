using System;
using System.Collections.Generic;

namespace PruebaIsaacC.Models
{
    public partial class estudiante
    {
        public estudiante()
        {
            this.asignacions = new List<asignacion>();
        }

        public int idEstudiante { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<asignacion> asignacions { get; set; }
    }
}
