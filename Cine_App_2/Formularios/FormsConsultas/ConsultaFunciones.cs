using Cine_App_2.Datos;
using Cine_App_2.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Cine_App_2.Formularios.FormsConsultas
{
    public partial class frmConsultaFunciones : Form
    {
        List<Parametros> parametros = new List<Parametros>();
        public string descripcion;
        public string nombreSp;
        
        public frmConsultaFunciones()
        {
            InitializeComponent();
            obtenerCombos();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = descripcion;
            dtpHasta.Value = DateTime.Today;

        }
        private void obtenerCombos()
        {
            obtenerFunciones();
            obtenerGeneros();
        }

        private void obtenerGeneros()
        {
           string query = "SELECT 0 as COD_GENERO,' Elejir Genero ' as NOMBRE\r\nunion\r\nSelect * From Generos";
           cbGenero.DataSource = ConsultasData.ConsultaTablaRetorno(query);
           cbGenero.ValueMember = "COD_GENERO";
           cbGenero.DisplayMember = "NOMBRE";
        }

        private void obtenerFunciones()
        {   
            //Realizo esto para agregar un registro vacio en la primera fila
           string query = "SELECT 0 as COD_FUNCION,' Elejir Funcion ' as NOMBRE\r\nunion\r\nSELECT \r\nF.COD_FUNCION, P.NOMBRE + '-'+ convert(varchar, F.FECHA, 22) as NOMBRE\r\nFROM FUNCIONES F  \r\nJOIN PELICULAS P ON P.COD_PELICULA = F.COD_PELICULA";
           cboFunciones.DataSource = ConsultasData.ConsultaTablaRetorno(query);
           cboFunciones.ValueMember = "COD_FUNCION";
           cboFunciones.DisplayMember = "NOMBRE";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parametros.Add(new Parametros("@funcion", (((DataRowView)cboFunciones.SelectedValue).Row.ItemArray[0].ToString())));
            parametros.Add(new Parametros("@desde"  , dtpDesde.Value.ToString()));
            parametros.Add(new Parametros("@hasta"  , dtpHasta.Value.ToString()));

            DataTable Resultado = ConsultasData.ConsultaTablaRetorno("PA_REPORTE_ENTRADAS", true, parametros);
            if (Resultado.Rows.Count > 0)
            {
                if (!Resultado.Rows[0].ItemArray[0].ToString().Contains("La fecha desde no puede ser mayor a la fecha hasta"))
                {
                    dgvResultados.DataSource = Resultado;
                }
                else
                {
                    MessageBox.Show("La fecha desde no puede ser mayor ni igual a la fecha hasta");
                }
            }
            else
            {
                MessageBox.Show("No hay resultados");
            }
 
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtPelicula.Text == "")
            {
                MessageBox.Show("El Campo Genero No puede quedar vacio");
                txtPelicula.Focus();
            }
            if (cboFunciones.SelectedIndex == 0)
            {
                MessageBox.Show("Debe asignar funciones apropiada");
                cboFunciones.Focus();
            }
            if (cbGenero.SelectedIndex == 0)
            {
                MessageBox.Show("Debe indicar el genero de la pelicula");
                cbGenero.Focus();  
            }
            try
            {
                prNuevaFuncion();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void prNuevaFuncion()
        {
            parametros.Add(new Parametros("@IDPelicula",txtPelicula.Text ));
            parametros.Add(new Parametros("@IDSala", (((DataRowView)cbGenero.SelectedValue).Row.ItemArray[0].ToString())));
           try
            {

            }
            catch
            {
                throw;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevaPelicula np = new frmNuevaPelicula();
            np.Text = "Modificar Pelicula";
            np.StartPosition = FormStartPosition.CenterScreen;
            np.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewCell f = dgvResultados.CurrentCell = this.dgvResultados[1, 0];
            f = dgvResultados[1, 0];
            /*
             * bool resultado = MessageBox.Show("Confirma eliminar el registro: "+ f,
                                            "Confirmacion de Eliminacion",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question
                                            );
            */
            DialogResult dialogResult = MessageBox.Show("Confirma eliminar el registro: " + f.ToString(),
                                                         "Confirmacion eliminacion",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);
            //bool resultado = ((bool)dialogResult);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string stQuery = "Select ";
            string stNExo = " Where ";

            stQuery += dtpDesde.Value.ToString() + dtpHasta.Value.ToString();
            if (txtPelicula.Text != "")
            {
                stQuery += txtPelicula.Text;
                stNExo += " AND ";
            }
            if (cboFunciones.SelectedIndex != 0)
            {
                stQuery += cboFunciones.Text;
                stNExo += " AND ";
            }
            if (cbGenero.SelectedIndex != 0)
                stQuery += cbGenero.Text;
            try
            {
                dgvResultados.DataSource = ConsultasData.ConsultaTablaRetorno(stQuery);
            }
            catch 
            {
                MessageBox.Show("Ocurrio un Error durante la carga de datos");
            }
        }

        private void btnNuevaPeliucla_Click(object sender, EventArgs e)
        {
            frmNuevaPelicula np = new frmNuevaPelicula();
            np.StartPosition = FormStartPosition.CenterParent;
            np.ShowDialog();
        }
    }
}
