using Cine_App_2.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Cine_App_2.Formularios.FormsConsultas
{
    public partial class ConsultaFunciones : Form
    {
        public string descripcion;
        public string nombreSp;
        List<Parametros> AuxParametros = new List<Parametros>();
        public ConsultaFunciones()
        {
            InitializeComponent();
            obtenerCombos();
            obtenerFunciones();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = descripcion;
            var today = DateTime.Today;
            dtpHasta.Value = today.AddDays(1);

        }
        private void obtenerCombos()
        {
            obtenerFunciones();

        }

        private void obtenerFunciones()
        {
            cboFunciones.DataSource = ConsultasData.ejecutarSpParams("PA_OBT_FUNCIONES");
            cboFunciones.ValueMember = "COD_FUNCION";
            cboFunciones.DisplayMember = "NOMBRE";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuxParametros.Add(new Parametros("@funcion", cboFunciones.SelectedItem.ToString()));
            AuxParametros.Add(new Parametros("@desde", dtpDesde.Value.ToString()));
            AuxParametros.Add(new Parametros("@hasta", dtpHasta.Value.ToString()));

            DataTable Resultado = ConsultasData.ejecutarSpParams("PA_REPORTE_ENTRADAS", AuxParametros);
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
    }
}