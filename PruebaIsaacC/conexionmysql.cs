using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using MySql.Data;
using System.Diagnostics;
using System.IO;

namespace PruebaIsaacC
{
    class conexionmysql
    {
        public static MySqlConnection Conex = new MySqlConnection();
        public MySqlCommand Comando = new MySqlCommand();
        public static MySqlDataAdapter Adaptador = new MySqlDataAdapter();
        public static string CadenaDeConexion = "";

        public void conexionMysql() { }
        /// <summary>
        /// Ingresar el nombre del servidor generalmente localhost
        /// El nombre de la Base de Datos
        /// UID generalmente root
        /// Contraseña
        /// </summary>
        /// <param name="NombreServidor"></param>
        /// <param name="NombreBaseD"></param>
        /// <param name="ubicacion"></param>
        /// <param name="pasword"></param>
        /// //


        public void IngrearCadena(string NombreServidor, string NombreBaseD, string ubicacion, string pasword, string puerto)
        {
            string cadena = "Server=" + "localhost" + ";Database=" + "mydb" + ";UID=" + "localhost" + ";Password=" + "root" + ";Port=" + "3306" + ";";
            CadenaDeConexion = cadena;

        }
        /// <summary>
        /// Metodo que recibe la cadena completa de conexion server=nombreServidor, etc
        /// </summary>
        /// <param name="cadena"></param>
        public void ingresarcadenacompleta(string cadena)
        {
            CadenaDeConexion = cadena;

        }
        /// <summary>
        /// Metodo que inicia la conexion
        /// </summary>
        public void Conectar()
        {
            try
            {
                Conex.ConnectionString = CadenaDeConexion;
                Conex.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Algo salio mal", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }
        /// <summary>
        /// Metodo que cierra la conexion
        /// </summary>
        public void Desconectar()
        {
            try
            {
                Conex.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Algo salio mal", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            }
        }
        public void ConsultaSimple(string consulta)
        {
            string Comando = consulta;
            Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);


        }
        /// <summary>
        /// Metodo que permite hacer una consluta
        /// retorna un Dataset
        /// </summary>
        /// <param name="campos"></param>
        /// <param name="nombreTabla"></param>
        /// <returns></returns>
        public DataSet ConsultarS(string campos, string nombreTabla)
        {
            DataSet tmp = new DataSet();
            try
            {
                Conectar();

                string consulta = "select " + campos + " from " + nombreTabla;
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, Conex);
                da.Fill(tmp);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Algo salio mal", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            finally
            {
                Desconectar();
            }

            return tmp;
        }
        /// <summary>
        /// Metodo que inserta los valores en una determinada tabla
        /// el orden debe estar separado de coma al igual que los valores
        /// Tener presente que los valores deben de estar de la siguente
        /// forma "'valor1','valor2'" igual que la insecion en mysql
        /// </summary>
        /// <param name="nombreTabla"></param>
        /// <param name="orden"></param>
        /// <param name="valores"></param>
        public void InsertaSimple(string nombreTabla, string orden, string valores)
        {
            string consulta = "Insert Into " + nombreTabla + "(" + orden + ") " + "values" + "(" + valores + ")";
            try
            {
                Conectar();
                Comando.Connection = Conex;
                Comando.CommandText = consulta;
                Comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Algo salio mal", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            }
            finally
            {
                Desconectar();
            }
        }
        public void insertarconCondicion(string nombreTabla, string orden, string valores,string condicion)
        {
            string consulta = "Insert Into " + nombreTabla + "(" + orden + ") " + "values" + "(" + valores + ")"+" where= "+condicion;
            try
            {
                Conectar();
                Comando.Connection = Conex;
                Comando.CommandText = consulta;
                Comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Algo salio mal", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            }
            finally
            {
                Desconectar();
            }
        }
        /// <summary>
        /// Metodo que realiza una consulta
        /// regresa un dataset con los campos de la consulta
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public DataSet ConsultaGenerarl(string c)
        {

            DataSet tmp = new DataSet();
            try
            {
                Conectar();

                string consulta = c;
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, Conex);
                da.Fill(tmp);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Algo salio mal", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            finally
            {
                Desconectar();
            }

            return tmp;

        }
        public DataSet consultaConWhere(string campos, string nombreTabla, string condiCion)
        {
            string cons = "select " + campos + " from  " + nombreTabla + " where " + condiCion;
            DataSet t = null; ;
            try
            {
                t = ConsultaGenerarl(cons);
                return t;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Algo salio mal", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            }
            return t = new DataSet(); ;
        }
        public void AcutalizarUnCampo(string nombreTabla, string NombredelCampoaModificar, string nuevoValor, string condicion)
        {
            string actualizar = "update " + nombreTabla + " set " + NombredelCampoaModificar + " = " + "'" + nuevoValor + "'" + " where " + condicion;
            EjecutarCons(actualizar);
        }
        /// <summary>
        /// Metodo para eleminar un registro de una tabla
        /// </summary>
        /// <param name="nombreTabla"></param>
        /// <param name="nombreid"></param>
        /// <param name="valorId"></param>
        public void EliminarD(string nombreTabla, string nombreid,string valorId) { 
        string consulta="delete from "+nombreTabla+"where "+nombreid+"="+valorId;
            EjecutarCons(consulta);
        }

        /// <summary>
        /// Metodo para ejecutar consultas de tipo insert, updete, delete (no devuelven valor)
        /// </summary>
        /// <param name="consulta"></param>
        public void EjecutarCons(string consulta)
        {
            try
            {
                Conectar();
                Comando.Connection = Conex;
                Comando.CommandText = consulta;
                Comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Algo salio mal", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            }
            finally
            {
                Desconectar();
            }
        }



        public void copiaS(string nombreBD, string ip_del_servidor, string usuario, string clave)
        {
            try
            {
                SaveFileDialog fd;
                fd = new SaveFileDialog();
                DialogResult dialogo;
                dialogo = fd.ShowDialog();
                string fichero = "";
                if (dialogo == DialogResult.OK)
                {
                    if (fd.FileName != String.Empty)
                    {
                        String linea;
                        fichero = fd.FileName;
                        System.Diagnostics.Process proc = new System.Diagnostics.Process();
                        proc.EnableRaisingEvents = false;
                        proc.StartInfo.UseShellExecute = false;
                        proc.StartInfo.RedirectStandardOutput = true;
                        proc.StartInfo.FileName = "mysqldump";
                        proc.StartInfo.Arguments = nombreBD + " --single-transaction --host=" + ip_del_servidor + " --user=" + usuario + " --password=" + clave;
                        Process miProceso;
                        miProceso =  Process.Start(proc.StartInfo);
                        StreamReader sr = miProceso.StandardOutput;
                        TextWriter tw = new StreamWriter(fd.FileName + " " + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".sql", false, Encoding.Default);
                       // TextWriter tw = new StreamWriter(fd.FileName + ".sql", false, Encoding.Default);
                       
                        while ((linea = sr.ReadLine()) != null)
                        {
                            tw.WriteLine(linea);
                        }
                        //   File.Encrypt(fd.FileName + " " + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".sql", false, Encoding.Default);
                        tw.Close();
                        MessageBox.Show("Copia de seguridad realizada con éxito");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al intentar la copia de seguridad", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            }
        }
    }
}


