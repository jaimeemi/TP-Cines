using Cine_App_2.Datos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevaFuncion nf = new frmNuevaFuncion();
            nf.StartPosition = FormStartPosition.CenterScreen;
            nf.ShowDialog();
            if (nf == null)
                btnConsultar_Click(sender, e);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvResultados.Rows.Count != 0)
            {
                frmNuevaPelicula np = new frmNuevaPelicula();
                np.Text = "Modificar Pelicula";
                np.StartPosition = FormStartPosition.CenterScreen;
                np.CodigoPelicula = (int)dgvResultados.CurrentRow.Cells[1].Value;
                np.CargarDatosPelicula(dgvResultados.CurrentRow);
                np.Show();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvResultados.Rows.Count != 0)
            {
                int idpelicula = (int)((DataGridViewRow)dgvResultados.CurrentRow).Cells[1].Value;
                string NombreFuncion =
                    ((DataGridViewRow)dgvResultados.CurrentRow).Cells[2].Value.ToString() + " " +//Este es Nombre de la Pelicula
                    ((DataGridViewRow)dgvResultados.CurrentRow).Cells[0].Value.ToString() + " " + //Estas es la Fecha
                    ((DataGridViewRow)dgvResultados.CurrentRow).Cells[7].Value.ToString(); //Esta es la Sala

                DialogResult dialogResult = MessageBox.Show("Confirma eliminar la funcion: " + NombreFuncion,
                                                             "Confirmacion eliminacion",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes) 
                {
                    string a = ((DataGridViewRow)dgvResultados.CurrentRow).Cells[1].Value.ToString();
                    parametros.Clear();
                    parametros.Add(new Parametros("@pIDFuncion", a ));
                    string query = "prBorrarFuncion";
                    try
                    {
                        ConsultasData.EjecutarSP(query, true, parametros);
                        MessageBox.Show("El Registro ha sido eliminado con exito!");
                        btnConsultar_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error durante la eliminacion de la funcion. Detalles tecnicos: "+ex.Message);
                    }                    
                }
            }
        }
        
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string stQuery = "Select Distinct * From vFunciones";

            stQuery += " Where FECHA >= '"+dtpDesde.Value.ToString()+"' And FECHA <= '"+ dtpHasta.Value.ToString()+"'";
            if (txtPelicula.Text != "")
                stQuery += " AND PELICULA like Upper('"+txtPelicula.Text+"%')";
            if (cbGenero.SelectedIndex != 0)
                stQuery += " AND COD_GENERO = "+cbGenero.SelectedIndex;
            if (cbSalas.SelectedIndex != 0)
                stQuery += " AND COD_SALA = " + cbSalas.SelectedIndex;
            if (cbIdiomas.SelectedIndex != 0)
                stQuery += " AND COD_IDIOMA = " + cbIdiomas.SelectedIndex;

            dgvResultados.DataSource = null;
            try
            {
                dgvResultados.DataSource = ConsultasData.ConsultaTablaRetorno(stQuery);
                //Escondo columnas Solo son usadas para filtrar
                dgvResultados.Columns["COD_PELICULA"].Visible = false;
                dgvResultados.Columns["COD_GENERO"].Visible = false;
                dgvResultados.Columns["COD_SALA"].Visible = false;
                dgvResultados.Columns["COD_IDIOMA"].Visible = false;
                dgvResultados.Columns["COD_FUNCION"].Visible = false;
                dgvResultados.Columns["COD_CLASIFICACION_INCA"].Visible = false;
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
