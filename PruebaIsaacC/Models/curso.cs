using System;
using System.Collections.Generic;

namespace PruebaIsaacC.Models
{
    public partial class curso
    {
        public curso()
        {
            this.asignacions = new List<asignacion>();
            this.tareas = new List<tarea>();
        }

        public int idCurso { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<asignacion> asignacions { get; set; }
        public virtual ICollection<tarea> tareas { get; set; }
    }
}
