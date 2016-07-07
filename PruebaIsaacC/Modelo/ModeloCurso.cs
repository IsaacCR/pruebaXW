using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIsaacC.Modelo
{
    class ModeloCurso
    {
        public int idCurso { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<ModeloTareas> ListaTareas { get; set; }
    }
}
