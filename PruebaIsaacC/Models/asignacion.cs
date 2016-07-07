using System;
using System.Collections.Generic;

namespace PruebaIsaacC.Models
{
    public partial class asignacion
    {
        public int Estudiante_idEstudiante { get; set; }
        public int Curso_idCurso { get; set; }
        public Nullable<int> NotaFinal { get; set; }
        public virtual curso curso { get; set; }
        public virtual estudiante estudiante { get; set; }
    }
}
