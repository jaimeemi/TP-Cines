﻿using Cine_App_2.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Cine_App_2.Formularios
{
    public partial class frmNuevaPelicula : Form
    {
        private List<Parametros> ls = new List<Parametros>();
        public int CodigoPelicula {  get; set; }
        private bool Modificacion {  get; set; }

        private PeliculaDAO pelicula;
        public frmNuevaPelicula()
        {
            InitializeComponent();
            prCargarCombos();
            Modificacion = false;
        }
        public void CargarDatosPelicula(DataGridViewRow datos)
        {
            ls.Add(new Parametros("@IdPeli", datos.Cells[1].Value.ToString()));
            string sinopsis = ConsultasData.ConsultaRetornaString("fxSinopsisPeli ", false, ls);
            pelicula = new PeliculaDAO(
                (int)datos.Cells[1].Value, //Codigo pelicula
                datos.Cells[2].Value.ToString(),//nombre
                datos.Cells[3].Value.ToString(),// productora
                sinopsis,// sinopsis
                (int)datos.Cells[6].Value,// COD_CLASIFICACION_INCA
                (int)datos.Cells[11].Value,//idioma
                (bool)datos.Cells[4].Value//Subtitulada
                );
            Modificacion = true;
            datos.Cells[7].Value.ToString();
        }

        private void prCargarCombos()
        {
            //CargarGeneros();
            CargarIdiomas();
            CargaINCA();
        }
        /*
        private void CargarGeneros()
        {
            string query = "select * from GENEROS ";// + (Modificacion ? " Where COD_GENERO = "+ : "");
            
            cbgenero.DataSource = ConsultasData.ConsultaTablaRetorno("select * from GENEROS");
            cbgenero.DisplayMember = "NOMBRE";
            cbgenero.ValueMember = "COD_GENERO";
        }
        */
        
        private void CargarIdiomas()
        {
            cbIdioma.DataSource = ConsultasData.ConsultaTablaRetorno("select * from IDIOMAS");
            cbIdioma.DisplayMember = "NOMBRE";
            cbIdioma.ValueMember = "COD_IDIOMA";
        }

        private void CargaINCA()
        {
            cbINCA.DataSource = ConsultasData.ConsultaTablaRetorno("Select * from CLASIFICACIONES_INCA");
            cbINCA.DisplayMember = "NOMBRE";
            cbINCA.ValueMember = "COD_CLASIFICACION_INCA";
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
            /*
            if (cbgenero.SelectedIndex == 0)
            {
                MessageBox.Show("la Pelicula debe poseer un Genero. Asignelo");
                cbgenero.Focus();

            }
            */
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
            ls.Add(new Parametros("@Clasificacion" , cbINCA.SelectedValue.ToString()));
            ls.Add(new Parametros("@Subtitulada"   , chSubtitulada.Checked ? "1" : "0"));
            // ls.Add(new Parametros("@Genero"        , cbgenero.SelectedValue.ToString()));
            ls.Add(new Parametros("@Idioma"        , cbIdioma.SelectedValue.ToString()));
            

            try
            {
                ConsultasData.EjecutarSP("spNuevaPelicula", true, ls);
                MessageBox.Show("Nueva Pelicula Grabada con Exito!");
                Dispose();
            }
            catch (Exception E)
            {
                MessageBox.Show("Error durante el proceso de grabacion. Datos tecnicos:" + E.Message);
                throw;
            }
        }
    }
}
