using System;
using System.Collections.Generic;

namespace PruebaIsaacC.Models
{
    public partial class tarea
    {
        public int idTarea { get; set; }
        public Nullable<int> Nota { get; set; }
        public Nullable<int> Tipo { get; set; }
        public int Curso_idCurso { get; set; }
        public virtual curso curso { get; set; }
    }
}
