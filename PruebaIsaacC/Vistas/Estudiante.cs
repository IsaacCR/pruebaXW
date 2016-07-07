using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PruebaIsaacC.Models;
using PruebaIsaacC.Models.Mapping;
namespace PruebaIsaacC
{
    public partial class Estudiante : Form
    {
        public Estudiante()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Estudiante_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Asignacion formularioAsingacion = new Asignacion();
            formularioAsingacion.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                using (var dbCtx = new mydbContext())
                {

                    estudiante nuevoe = new estudiante();
                    nuevoe.Nombre = textBox1.Text;
                    dbCtx.estudiantes.Add(nuevoe);
                    //dbCtx.Entry(new estudianteMap()).State = System.Data.Entity.EntityState.Added;

                    dbCtx.SaveChanges();
                }
            }
            catch (Exception err) {
            
            }
        }
    }
}
