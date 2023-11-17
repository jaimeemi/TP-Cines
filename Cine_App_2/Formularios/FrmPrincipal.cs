using Cine_App_2.Formularios;
using Cine_App_2.Formularios.FormsConsultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;

namespace Cine_App_2
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
         //   Para la musica 
         //   SoundPlayer player = new SoundPlayer();
         //   player.SoundLocation = @"C:\Users\dolor\OneDrive\Escritorio\CINEMA_PROGII\MUSICA_CINE_PROG2\\swwav.wav";
         //   player.Play();
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void cargarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmReserva nuevo = new FrmReserva();
            nuevo.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)   
            {
                Application.Exit();
            }
            
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes nuevo = new FrmClientes();
            nuevo.Show();
        }


        //consulta 5
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            frmConsultaFunciones form = new frmConsultaFunciones();
            form.Show();
        }


        //consulta 6
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Ticket form = new Ticket();
            form.descripcion = "";
            form.Show();
        }

        //consulta 7
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7();
            form.descripcion = "Traer los importes totales, por segmentos (JUBILADOS, MAYORES, MENORES), " + "\n" +
                "para determinado período de fechas.";
            form.nombreSp = "PA_TOTALES_POR_SEGMENTO_POR_PERIODO";
            form.Show();
        }


        private void equipoDeDesarrolloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEquipo form = new FormEquipo();
            form.Show();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide(); //cierra el form principal 
            FormLogin login = new FormLogin();
            login.Show();
        }

        private void reporteFuncionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide(); //cierra el form principal 
            FrmReporteFunciones Reporte = new FrmReporteFunciones();
            Reporte.Show();
        }

        private void consultaFunciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaFunciones con = new frmConsultaFunciones();
            con.StartPosition = FormStartPosition.CenterParent;
            con.Show();
        }
    }
}
