using Cine_App_2.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cine_App_2.Formularios.FormsConsultas
{
    public partial class frmNuevaFuncion : Form
    {
        public bool GRABOFUNCION {  get; set; }
        private List<Parametros> parametros = new List<Parametros>();
        public frmNuevaFuncion()
        {
            InitializeComponent();
            GRABOFUNCION = false;
            ObtenerSalas();
            ObtenerPeliculas();
            dtpDesde.Value = DateTime.Now;
        }

        private void ObtenerSalas()
        {
            string query = "Select 0 as COD_SALA,  ' '  as Nombre\r\nFrom Salas s\r\nunion\r\nSelect COD_SALA,  Nombre\r\nFrom Salas s\r\n";
            cbSala.DataSource = ConsultasData.ConsultaTablaRetorno(query);
            cbSala.ValueMember = "COD_SALA";
            cbSala.DisplayMember = "NOMBRE";
        }

        private void ObtenerPeliculas()
        {
            string query = "select 0 as COD_PELICULA, ' elejir pelicula' as Nombre\r\nunion \r\nselect COD_PELICULA, Nombre\r\nfrom peliculas";
            cbSala.DataSource = ConsultasData.ConsultaTablaRetorno(query);
            cbSala.ValueMember = "COD_SALA";
            cbSala.DisplayMember = "NOMBRE";
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (cbPelicula.SelectedIndex == 0)
            {
                MessageBox.Show("Debe selecciona la pelicula para la funcion");
                cbPelicula.Focus();
            }
            if (cbSala.SelectedIndex == 0)
            {
                MessageBox.Show("Debe selecciona una sala");
                cbSala.Focus();
            }

            DialogResult dialogResult = MessageBox.Show("Confirma la funcion: ",
                                                        "Confirmar",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                parametros.Add(new Parametros("@IDPelicula", cbPelicula.SelectedIndex.ToString()));
                parametros.Add(new Parametros("@IDSala", cbSala.SelectedIndex.ToString()));
                try
                {
                    ConsultasData.EjecutarSP("spNuevaFuncion", true, parametros);
                    MessageBox.Show("Se Grabo con exito la funcion");
                    GRABOFUNCION = true;
                    Dispose();
                }
                catch 
                {
                    MessageBox.Show("Algun dato se encuentra incorrecto");
                    GRABOFUNCION = false;
                }
            }
        }
    }
}
