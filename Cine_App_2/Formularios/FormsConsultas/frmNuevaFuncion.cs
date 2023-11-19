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
        private List<Parametros> parametros = new List<Parametros>();
        public frmNuevaFuncion()
        {
            InitializeComponent();
            ObtenerSalas();
            ObtenerPeliculas();
            dtpDesde.Value = DateTime.Now;
        }

        private void ObtenerSalas()
        {
            string query = "Select 0 as COD_SALA,  ' '  as Nombre From Salas union Select COD_SALA,  Nombre From Salas";
            cbSala.DataSource = ConsultasData.ConsultaTablaRetorno(query);
            cbSala.ValueMember = "COD_SALA";
            cbSala.DisplayMember = "NOMBRE";
        }

        private void ObtenerPeliculas()
        {
            string query = "select 0 as COD_PELICULA, ' elejir pelicula' as Nombre union select COD_PELICULA, Nombre from peliculas";
            cbPelicula.DataSource = ConsultasData.ConsultaTablaRetorno(query);
            cbPelicula.ValueMember = "COD_PELICULA";
            cbPelicula.DisplayMember = "NOMBRE";
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (cbPelicula.SelectedIndex == 0)
            {
                MessageBox.Show("Debe selecciona la pelicula para la funcion");
                return;
                cbPelicula.Focus();
            }
            if (cbSala.SelectedIndex == 0)
            {
                MessageBox.Show("Debe selecciona una sala"); 
                return;
                cbSala.Focus();
            }
            
            string NombreFUncion = ((DataRowView)cbPelicula.Items[cbPelicula.SelectedIndex]).Row.ItemArray[1] + " "+
                                   dtpDesde.Value.ToString() + " " +
                                   ((DataRowView)cbSala.Items[cbSala.SelectedIndex]).Row.ItemArray[1];
            DialogResult dialogResult = MessageBox.Show("Confirma la funcion: " + NombreFUncion,
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
                    Dispose();
                }
                catch 
                {
                    MessageBox.Show("Algun dato se encuentra incorrecto");
                }
            }
        }

        private void frmNuevaFuncion_Leave(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
