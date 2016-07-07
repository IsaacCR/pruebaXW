using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIsaacC.Modelo
{
    class ModeloEstudiante
    {
         public int idEstudiante { get; set; }
    public string Nombre { get; set; }

    public virtual ICollection<ModeloAsignaciones> ListadoAsingaciones { get; set; }

    }
}
