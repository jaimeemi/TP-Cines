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
        private List<Parametros> parametros = new List<Parametros>();
        
        public frmConsultaFunciones()
        {
            InitializeComponent();
            obtenerCombos();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Parse("01/01/2000");
            dtpHasta.Value = DateTime.Today;

        }
        private void obtenerCombos()
        {
            obtenerFunciones();
            obtenerGeneros();
            ObtenerSalas();
            ObtenerIdiomas();
        }

        private void ObtenerIdiomas()
        {
            string query = "Select 0 as COD_IDIOMA,  ' '  as Nombre\r\nFrom IDIOMAS \r\nunion\r\nSelect COD_IDIOMA,  Nombre\r\nFrom IDIOMAS ";
            cbIdiomas.DataSource = ConsultasData.ConsultaTablaRetorno(query);
            cbIdiomas.ValueMember = "COD_IDIOMA";
            cbIdiomas.DisplayMember = "NOMBRE";
        }

        private void ObtenerSalas()
        {
            string query = "Select 0 as COD_SALA,  ' '  as Nombre\r\nFrom Salas s\r\nunion\r\nSelect COD_SALA,  Nombre\r\nFrom Salas s\r\n";
            cbSalas.DataSource = ConsultasData.ConsultaTablaRetorno(query);
            cbSalas.ValueMember = "COD_SALA";
            cbSalas.DisplayMember = "NOMBRE";
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
           string query = "SELECT 0 as COD_FUNCION,' Elejir Funcion ' as NOMBRE\r\nunion\r\nSELECT \r\nF.COD_FUNCION, P.NOMBRE + '-'+ convert(varchar, F.FECHA, 22) as NOMBRE\r\nFROM FUNCIONES F  \r\nJOIN PELICULAS P ON P.COD_PELICULA = F.COD_PELICULA";
           cboFunciones.DataSource = ConsultasData.ConsultaTablaRetorno(query);
           cboFunciones.ValueMember = "COD_FUNCION";
           cboFunciones.DisplayMember = "NOMBRE";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        /*
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
        */

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
            if (dgvResultados.Rows.Count != 0)
            {
                frmNuevaPelicula np = new frmNuevaPelicula();
                np.Text = "Modificar Pelicula";
                np.StartPosition = FormStartPosition.CenterScreen;
                np.CodigoPelicula = (int)((DataGridViewRow)dgvResultados.SelectedRows[dgvResultados.CurrentRow.Index]).Cells[1].Value;
                np.CargarDatosPelicula();
                np.Show();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvResultados.Rows.Count != 0)
            {
                int idpelicula = (int)((DataGridViewRow)dgvResultados.Rows[0]).Cells[1].Value;
                string NombreFuncion =
                    ((DataGridViewRow)dgvResultados.SelectedRows[dgvResultados.CurrentRow.Index]).Cells[1].ToString() + " " +//Este es Nombre de la Pelicula
                    ((DataGridViewRow)dgvResultados.SelectedRows[dgvResultados.CurrentRow.Index]).Cells[0].ToString() + " " + //Estas es la Fecha
                    ((DataGridViewRow)dgvResultados.SelectedRows[dgvResultados.CurrentRow.Index]).Cells[7].ToString(); //Esta es la Sala
                /*
                 * bool resultado = MessageBox.Show("Confirma eliminar el registro: "+ f,
                                                "Confirmacion de Eliminacion",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question
                                                );
                */
                DialogResult dialogResult = MessageBox.Show("Confirma eliminar el registro: " + NombreFuncion,
                                                             "Confirmacion eliminacion",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question);

                if (((int)dialogResult) == 0)
                {
                    string a = ((DataGridViewRow)dgvResultados.SelectedRows[dgvResultados.CurrentRow.Index]).Cells[1].ToString();
                    parametros.Add(new Parametros("@pIDFuncion", a ));
                    string query = "prBorrarFuncion";
                    try
                    {
                        ConsultasData.EjecutarSP(query, true, parametros);
                    }catch (Exception ex)
                    {
                        MessageBox.Show("Error durante la eliminacion de la funcion. Detalles tecnicos: "+ex.Message);
                    }
                    
                }
            }
        }
        
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string stQuery = "Select * From vFunciones";

            stQuery += " Where FECHA >= '"+dtpDesde.Value.ToString()+"' And FECHA <= '"+ dtpHasta.Value.ToString()+"'";
            if (txtPelicula.Text != "")
                stQuery += " AND PELICULA like Upper('"+txtPelicula.Text+"%')";
            if (cboFunciones.SelectedIndex != 0)
                stQuery += " AND COD_FUNCION = " + cboFunciones.SelectedIndex;
            if (cbGenero.SelectedIndex != 0)
                stQuery += " AND COD_GENERO = "+cbGenero.SelectedIndex;
            if (cbSalas.SelectedIndex != 0)
                stQuery += " AND COD_SALA = " + cbSalas.SelectedIndex;
            if (cbIdiomas.SelectedIndex != 0)
                stQuery += " AND COD_IDIOMA = " + cbIdiomas.SelectedIndex;

            try
            {
                dgvResultados.DataSource = ConsultasData.ConsultaTablaRetorno(stQuery);
                //Escondo columnas Solo son usadas para filtrar
                dgvResultados.Columns["COD_PELICULA"].Visible = false;
                dgvResultados.Columns["COD_FUNCION"].Visible = false;
                dgvResultados.Columns["COD_GENERO"].Visible = false;
                dgvResultados.Columns["COD_SALA"].Visible = false;
                dgvResultados.Columns["COD_IDIOMA"].Visible = false;
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
