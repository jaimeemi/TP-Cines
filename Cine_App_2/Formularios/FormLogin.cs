using Cine_App_2.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cine_App_2.Formularios
{
    public partial class FormLogin : Form
    {
        List<Parametros> AuxParametros = new List<Parametros>();
         
        public FormLogin()
        {
            InitializeComponent();
            btnIngresar.Focus();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.DimGray;

            }
        }
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "CONTRASEÑA")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "CONTRASEÑA";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            btnIngresar.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
           if(txtUsuario.Text == "USUARIO" || txtPassword.Text == "CONTRASEÑA" ||  txtUsuario.Text == "" || txtPassword.Text == "")
           {
                MessageBox.Show("Campos incompletos. Por favor completarlos para ingresar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
           }
            try
            {

                AuxParametros.Add(new Parametros("@USUARIO", txtUsuario.Text));
                AuxParametros.Add(new Parametros("@PASS", txtPassword.Text));
                DataTable result = ConsultasData.ejecutarSpParams("pa_login", AuxParametros);
                if (result.Rows.Count != 0)
                {
                    this.Hide();
                    FrmPrincipal principal = new FrmPrincipal();
                    principal.Show();
                }
                else
                {
                   //MessageBox.Show("Usuario o Contraseña Incorrectos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   // txtUsuario.Text = "";
                   // txtPassword.Text = "";
                   // txtPassword_Leave(sender, e);
                   // txtUsuario_Leave(sender, e);
                   // btnIngresar.Focus();
                   // AuxParametros.Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
