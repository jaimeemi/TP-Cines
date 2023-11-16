﻿using Cine_App_2.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace Cine_App_2.Formularios.FormsConsultas
{
    public partial class Form7 : Form
    {
        public string descripcion;
        public string nombreSp;
        List<Parametros> parametro = new List<Parametros>();
   
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.lblTitulo.Text = descripcion;

        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand();
           
            parametro.Add(new Parametros("@DESDE", dtpDesde.Value.ToString()));
            parametro.Add(new Parametros("@HASTA", dtpHasta.Value.ToString()));

            DataTable Resultado= ConsultasData.ejecutarSpParams("PA_TOTALES_POR_SEGMENTO_POR_PERIODO", parametro);
            if (Resultado.Rows.Count > 0)
            {
                DataRow row = Resultado.Rows[0];
                string status = row.ItemArray[0].ToString();
                if (!status.Contains(".") && status.Length > 1)
                {
                    MessageBox.Show(status);
                }
                else
                {
                    this.dgvResultados.DataSource = Resultado;
                }

            }
            else
            {
                MessageBox.Show("No hay resultados.");

            }
            //Exec PA_TOTALES_POR_SEGMENTO_POR_PERIODO, @DESDE = dtpDesde.Value, @HASTA = dtpHasta.Value;
        }

        private void dgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
