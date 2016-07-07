using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaIsaacC
{
    public partial class Asignacion : Form
    {
        protected int idEstudiante;
        protected int idCurso;
        public Asignacion()
        {
            InitializeComponent();
        }
        public void datos(int iEstudiante){
            this.idEstudiante = iEstudiante;


        }

        private void Asignacion_Load(object sender, EventArgs e)
        {

        }
    }
}
