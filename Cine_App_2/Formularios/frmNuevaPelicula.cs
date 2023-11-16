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

namespace Cine_App_2.Formularios
{
    public partial class frmNuevaPelicula : Form
    {
        List<Parametros> ls = new List<Parametros>();
        public frmNuevaPelicula()
        {
            InitializeComponent();
            prCargarCombos();
        }

        private void prCargarCombos()
        {
            CargarGeneros();
            CargarIdiomas();
            CargaINCA();
        }

        private void CargarGeneros()
        {
            cbgenero.DataSource = ConsultasData.ejecutarConsulta("select * from GENEROS");
            cbgenero.DisplayMember = "NOMBRE";
            cbgenero.ValueMember = "COD_GENERO";
        }
        
        private void CargarIdiomas()
        {
            cbgenero.DataSource = ConsultasData.ejecutarConsulta("select * from IDIOMAS");
            cbgenero.DisplayMember = "NOMBRE";
            cbgenero.ValueMember = "COD_IDIOMA";
        }

        private void CargaINCA()
        {
            cbgenero.DataSource = ConsultasData.ejecutarConsulta("Select * from CLASIFICACIONES_INCA");
            cbgenero.DisplayMember = "NOMBRE";
            cbgenero.ValueMember = "COD_IDIOMA";
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtPelicula.Text == "")
            {
                MessageBox.Show("Debe Ingresar Nombre de Pelicula");
                txtPelicula.Focus();
            }
            if (txtProductora.Text == "")
            {
                MessageBox.Show("Ingrese productora");
                txtProductora.Focus();
            }
            if (cbINCA.SelectedIndex == 0)
            {
                MessageBox.Show("categoria INCA no puede estar vacia ");
                cbINCA.Focus();
            }
            if (cbgenero.SelectedIndex == 0)
            {
                MessageBox.Show("la Pelicula debe poseer un Genero. Asignelo");
                cbgenero.Focus();

            }
            if (cbIdioma.SelectedIndex == 0)
            {
                MessageBox.Show("La pelicula posee un idioma original. Asignela!");
                cbIdioma.Focus();
            }

            try
            {
                prGrabarNuevaPelicula();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void prGrabarNuevaPelicula()
        {
            ls.Add(new Parametros("@Nombre"        , txtPelicula.Text));
            ls.Add(new Parametros("@Sinopsis"      , txtSinopsis.Text));
            ls.Add(new Parametros("@Productora"    , txtProductora.Text));
            ls.Add(new Parametros("@Clasificacion" , ((DataRowView)cbINCA.SelectedValue).Row.ItemArray[0].ToString()));
            ls.Add(new Parametros("@Idioma"        , ((DataRowView)cbIdioma.SelectedValue).Row.ItemArray[0].ToString()));
            ls.Add(new Parametros("@Subtitulada"   , chSubtitulada.Checked ? "1" : "0"));

            try
            {
                ConsultasData.EjecutalSP("spNuevaPelicula", true, ls);
                MessageBox.Show("Nueva Pelicula Grabada con Exito!");
                Dispose();
            }
            catch (Exception E)
            {
                MessageBox.Show("Datos tecnicos:" + E.Message);
                throw;
            }
        }
    }
}
