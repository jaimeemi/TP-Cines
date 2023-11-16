using Cine_App_2.Datos;
using Cine_App_2.Entidades;
using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Cine_App_2.Formularios.FormsConsultas
{
    public partial class Ticket : Form
    {

            public string descripcion;
            public string idFacturaRegistrado;
            List<TipoCliente> tiposClientes = new List<TipoCliente>();
            List<Parametros> AuxParametros = new List<Parametros>();
            public int idFactura;

            public Ticket()
            {
                InitializeComponent();
                gbTickets.Cursor = Cursors.Default;
                gbFactura.Cursor = Cursors.Default;
                obtenerCombos();
                idFactura = ConsultasData.ConsultaRetornaInt("Select Max(F.COD_FACTURA)+1 FROM FACTURAS F");
            }

            private void btnVolver_Click(object sender, EventArgs e)
            {
                Dispose();
            }

            private void obtenerCombos()
            {
                obtenerClientes();
                obtenerVendedores();
                obtenerTiposVentas();
                obtenerFunciones();
                obtenerSalas();
                obtenerButacasDisponibles();  
            }

            private void obtenerClientes()
            {
                DataTable lista = ConsultasData.ConsultaTablaRetorno("PA_OBT_CLIENTES");
                cboClientes.DataSource = lista;
                cboClientes.ValueMember = "COD_CLIENTE";
                cboClientes.DisplayMember = "NOMBRE";
            }

            private void obtenerVendedores()
            {
                DataTable lista = ConsultasData.ConsultaTablaRetorno("PA_OBT_VENDEDORES");
                cboVendedores.DataSource = lista;
                cboVendedores.ValueMember = "COD_VENDEDOR";
                cboVendedores.DisplayMember = "NOMBRE";

            }

            private void obtenerTiposVentas()
            {
                DataTable lista = ConsultasData.ConsultaTablaRetorno("PA_OBT_TIPO_V");
                cboTipoVenta.DataSource = lista;
                cboTipoVenta.ValueMember = "COD_TIPO_VENTA";
                cboTipoVenta.DisplayMember = "NOMBRE";
            }

            private void obtenerFunciones()
            {
                DataTable result = ConsultasData.ConsultaTablaRetorno("PA_OBT_FUNCIONES");
                cboFunciones.DataSource = result;
                cboFunciones.ValueMember = "COD_FUNCION";
                cboFunciones.DisplayMember = "NOMBRE";
            }

            private void obtenerSalas()
            {
                AuxParametros.Add(new Parametros("@idFuncion", ((DataRowView)cboFunciones.SelectedItem).Row.ItemArray[0].ToString()));
                DataTable result = ConsultasData.ConsultaTablaRetorno("PA_OBT_SALA_X_FUNCION",true, AuxParametros);
                cboSalas.DataSource = result;
                cboSalas.ValueMember = "cod_sala";
                cboSalas.DisplayMember = "NOMBRE";
                AuxParametros.Clear();
            }

            private void obtenerButacasDisponibles()
            {
                AuxParametros.Clear();
                AuxParametros.Add(new Parametros("@idFuncion", ((DataRowView)cboFunciones.SelectedItem).Row.ItemArray[0].ToString()));
                AuxParametros.Add(new Parametros("@idSala", ((DataRowView)cboSalas.SelectedItem).Row.ItemArray[0].ToString()));
                DataTable result = ConsultasData.ConsultaTablaRetorno("PA_OBT_BUTACAS_DISPONIBLES", true, AuxParametros);
                cboButacasDisp.DataSource = result;
                cboButacasDisp.ValueMember = "COD_BUTACA";
                cboButacasDisp.DisplayMember = "NRO_BUTACA";
                AuxParametros.Clear();
            }

            private void obtenerTiposClientes()
            {
                DataTable result = ConsultasData.ConsultaTablaRetorno("PA_OBT_TIPOS_C");
                cboTipoCliente.DataSource = result;
                foreach (DataRow row in result.Rows)
                {
                    cboTipoCliente.ValueMember = "COD_TIPO_CLIENTE";
                    cboTipoCliente.DisplayMember = "DESCRIPCION";
                    TipoCliente tc = new TipoCliente((int)row.ItemArray[0], (string)row.ItemArray[1], (decimal)row.ItemArray[2]);
                    tiposClientes.Add(tc);
                }
            }

            private void registrarFactura()
            {
               String Cliente = ((DataRowView)cboClientes.SelectedItem).Row.ItemArray[0].ToString();
               String Vendedor = ((DataRowView)cboVendedores.SelectedItem).Row.ItemArray[0].ToString();
               String TipoVenta = ((DataRowView)cboTipoVenta.SelectedItem).Row.ItemArray[0].ToString();
        
               AuxParametros.Add(new Parametros("@idCliente", Cliente));
               AuxParametros.Add(new Parametros("@idVendedor", Vendedor));
               AuxParametros.Add(new Parametros("@idTipoVenta", TipoVenta));

                try
                {
                ConsultasData.EjecutarSP("PA_REGISTRAR_FACTURA",true,  AuxParametros);
                    MessageBox.Show("Se Registro con exito el comprobante N°" + idFactura.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Durante la carga del comprobante. Datos Tecnicos: " + ex.Message);
                }
               AuxParametros.Clear();
            }

            private void btnRegistrar_Click(object sender, EventArgs e)
            {
                try
                {
                    registrarFactura();
                    gbTickets.Enabled = true;
                    gbFactura.Enabled = false;

                obtenerTiposClientes();
                }
                catch
                {
                    gbTickets.Enabled = false;
                    gbFactura.Enabled = true;
                }
            }

            private void cboFunciones_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cboFunciones.SelectedIndex > 0)
                {
                    obtenerSalas();
                }
            }

            private void btnRegistrarTicket_Click(object sender, EventArgs e)
            {
                gbFactura.Enabled = false;
                gbTickets.Enabled = true;
                string funcionStr = cboFunciones.Text.ToString();
                string salaStr = cboSalas.Text.ToString();
                string butaca = cboButacasDisp.Text.ToString();
                string resultado = registrarTicket();

                resultado = resultado != "OK" ? resultado : "TICKET FACTURA N°: " + idFacturaRegistrado + "\n" +
                                                            "Se ha registrado los tickets para la película: " + funcionStr + "\n" +
                                                            "Sala seleccionada: " + salaStr + "\n" +
                                                            "Butaca seleccionada: " + butaca;

                MessageBox.Show(resultado);
            }

            private string registrarTicket()
            {
                if (txPrecio.Text == "")
                {
                    return "El precio no puede estar vacío";
                }

                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = conexion.CreateCommand();
                try
                {
                    AuxParametros.Clear();
                    cmd.Parameters.Add(new Parametros("@idFactura", idFactura.ToString()));
                    cmd.Parameters.Add(new Parametros("@idFuncion", ((DataRowView)cboFunciones.SelectedItem).Row.ItemArray[0].ToString()));
                    cmd.Parameters.Add(new Parametros("@idButaca", ((DataRowView)cboButacasDisp.SelectedItem).Row.ItemArray[0].ToString()));
                    cmd.Parameters.Add(new Parametros("@precio", txPrecio.Text));
                    cmd.Parameters.Add(new Parametros("@idTipoCliente", ((DataRowView)cboTipoCliente.SelectedItem).Row.ItemArray[0].ToString()));

                     SqlParameter mensaje = new SqlParameter("@mensaje", SqlDbType.VarChar, 30)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter idFacturaParam = new SqlParameter("@idFactura", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(mensaje);
                    cmd.Parameters.Add(idFacturaParam);

                    DataTable result = ConsultasData.ConsultaTablaRetorno("PA_REGISTRAR_TICKET", true, AuxParametros);

                    DataRow row = result.Rows[0];

                    string status = row.ItemArray[0].ToString();

                    this.idFactura = Convert.ToInt32(row.ItemArray[1]);

                    PrintDocument pd = new PrintDocument();
                    PrinterSettings ps = new PrinterSettings();

                    pd.PrinterSettings = ps;
                    pd.PrintPage += printDocument1_PrintPage;
                    pd.DocumentName = "ticket-" + idFacturaParam.ToString();
                    pd.Print();

                    AuxParametros.Clear();
                    return status;
                }
                catch (Exception E)
                {
                    return E.Message;
                }
            }

            private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) ||
                    (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')))
                {
                    e.Handled = true;
                }
            }

            private void cboTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (tiposClientes.Count > 0)
                {
                    decimal precio = tiposClientes.FirstOrDefault(o => o.idTipoCliente == cboTipoCliente.SelectedIndex + 1).precio;

                    txPrecio.Text = precio.ToString();
                }

            }

            private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
            {
                AuxParametros.Add(new Parametros("@idFactura", idFactura.ToString()));

                DataTable impresion = ConsultasData.ConsultaTablaRetorno("PA_IMPRIMIR_TICKET");

                string nombrePelicula = impresion.Rows[0].ItemArray[0].ToString();
                string fecha = impresion.Rows[0].ItemArray[1].ToString();
                int nroButaca = Convert.ToInt32(impresion.Rows[0].ItemArray[2]);
                int nroSala = Convert.ToInt32(impresion.Rows[0].ItemArray[3]);
                Font font = new Font("Arial", 20, FontStyle.Bold);
                Font fontTitulo = new Font("Arial", 24, FontStyle.Bold);

                e.Graphics.DrawString("CINEMA 15 - REPORTE", fontTitulo, Brushes.Black, new RectangleF(220, 10, 1000, 40));
                e.Graphics.DrawString("Ticket numero: " + idFactura.ToString(), font, Brushes.Black, new RectangleF(0, 50, 1000, 40));
                e.Graphics.DrawString("-------------------------------------------------", fontTitulo, Brushes.Black, new RectangleF(0, 80, 1000, 40));
                e.Graphics.DrawString("Pelicula: " + nombrePelicula, font, Brushes.Black, new RectangleF(0, 110, 1000, 40));
                e.Graphics.DrawString("Fecha de emisión: " + fecha, font, Brushes.Black, new RectangleF(0, 140, 1000, 40));
                e.Graphics.DrawString("Número de butaca: " + nroButaca.ToString(), font, Brushes.Black, new RectangleF(0, 170, 1000, 40));
                e.Graphics.DrawString("Número de sala: " + nroSala.ToString(), font, Brushes.Black, new RectangleF(0, 200, 1000, 40));
                e.Graphics.DrawString("-------------------------------------------------", fontTitulo, Brushes.Black, new RectangleF(0, 250, 1000, 40));

                AuxParametros.Clear();
            }

        private void Ticket_Load(object sender, EventArgs e)
        {

        }

        private void cboVendedores_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void gbFactura_Enter(object sender, EventArgs e)
        {

        }
    }
}
    //public string descripcion;
    //public string idFacturaRegistrado;
    //List<TipoCliente> tiposClientes = new List<TipoCliente>();
    //public int idFactura;

    //public Form5()
    //{
    //    InitializeComponent();
    //    this.obtenerCombos();
    //    this.obtenerFunciones();
    //}

    //private void Form5_Load(object sender, EventArgs e)
    //{
    //}

    //private void btnVolver_Click(object sender, EventArgs e)
    //{
    //    this.Dispose();
    //}

    //private void obtenerCombos()
    //{
    //    this.obtenerClientes();
    //    this.obtenerVendedores();
    //    this.obtenerTiposVentas();
    //}

    //private void obtenerClientes()
    //{
    //    DataTable lista = ConsultasData.obtenerCombo("PA_OBT_CLIENTES");
    //    this.cboClientes.DataSource = lista;
    //    foreach (DataRow row in lista.Rows)
    //    {
    //        this.cboClientes.ValueMember = "COD_CLIENTE";
    //        this.cboClientes.DisplayMember = "NOMBRE";
    //    }
    //}

    //private void obtenerVendedores()
    //{
    //    DataTable lista = ConsultasData.obtenerCombo("PA_OBT_VENDEDORES");
    //    this.cboVendedores.DataSource = lista;
    //    foreach (DataRow row in lista.Rows)
    //    {
    //        this.cboVendedores.ValueMember = "COD_VENDEDOR";
    //        this.cboVendedores.DisplayMember = "NOMBRE";
    //    }
    //}

    //private void obtenerTiposVentas()
    //{
    //    DataTable lista = ConsultasData.obtenerCombo("PA_OBT_TIPO_V");
    //    this.cboTipoVenta.DataSource = lista;
    //    foreach (DataRow row in lista.Rows)
    //    {
    //        this.cboTipoVenta.ValueMember = "COD_TIPO_VENTA";
    //        this.cboTipoVenta.DisplayMember = "NOMBRE";
    //    }
    //}

    //private void obtenerFunciones()
    //{
    //    DataTable result = ConsultasData.obtenerCombo("PA_OBT_FUNCIONES");
    //    this.cboFunciones.DataSource = result;
    //    foreach (DataRow row in result.Rows)
    //    {
    //        this.cboFunciones.ValueMember = "COD_FUNCION";
    //        this.cboFunciones.DisplayMember = "NOMBRE";
    //    }
    //}

    //private void obtenerSalas()
    //{
    //    SqlCommand cmd = new SqlCommand();
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@idFuncion", this.cboFunciones.SelectedValue);
    //    DataTable result = ConsultasData.ejecutarSpParams("PA_OBT_SALA_X_FUNCION", cmd);
    //    this.cboSalas.DataSource = result;
    //    foreach (DataRow row in result.Rows)
    //    {
    //        this.cboSalas.ValueMember = "cod_sala";
    //        this.cboSalas.DisplayMember = "NOMBRE";
    //    }
    //    this.obtenerButacasDisponibles();
    //}

    //private void obtenerButacasDisponibles()
    //{
    //    SqlCommand cmd = new SqlCommand();
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@idFuncion", this.cboFunciones.SelectedValue);
    //    cmd.Parameters.AddWithValue("@idSala", this.cboSalas.SelectedValue);
    //    DataTable result = ConsultasData.ejecutarSpParams("PA_OBT_BUTACAS_DISPONIBLES", cmd);
    //    this.cboButacasDisp.DataSource = result;
    //    foreach (DataRow row in result.Rows)
    //    {
    //        this.cboButacasDisp.ValueMember = "COD_BUTACA";
    //        this.cboButacasDisp.DisplayMember = "NRO_BUTACA";
    //    }
    //}

    //private void obtenerTiposClientes()
    //{
    //    DataTable result = ConsultasData.obtenerCombo("PA_OBT_TIPOS_C");
    //    this.cboTipoCliente.DataSource = result;
    //    foreach (DataRow row in result.Rows)
    //    {
    //        this.cboTipoCliente.ValueMember = "COD_TIPO_CLIENTE";
    //        this.cboTipoCliente.DisplayMember = "DESCRIPCION";
    //        TipoCliente tc = new TipoCliente((int)row.ItemArray[0], (string)row.ItemArray[1], (decimal)row.ItemArray[2]);
    //        tiposClientes.Add(tc);
    //    }
    //}

    //private string registrarFactura()
    //{
    //    SqlCommand cmd = new SqlCommand();
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@idCliente", this.cboClientes.SelectedValue);
    //    cmd.Parameters.AddWithValue("@idVendedor", this.cboVendedores.SelectedValue);
    //    cmd.Parameters.AddWithValue("@idTipoVenta", this.cboTipoVenta.SelectedValue);
    //    SqlParameter idFactura = new SqlParameter();
    //    idFactura.ParameterName = "@idFactura";
    //    idFactura.SqlDbType = System.Data.SqlDbType.Int;
    //    idFactura.Direction = System.Data.ParameterDirection.Output;
    //    cmd.Parameters.Add(idFactura);
    //    SqlParameter mensaje = new SqlParameter("@mensaje", SqlDbType.VarChar, 20);
    //    mensaje.Direction = System.Data.ParameterDirection.Output;
    //    cmd.Parameters.Add(mensaje);
    //    ConsultasData.EjecutarSP("PA_REGISTRAR_FACTURA", cmd);
    //    return idFactura.Value.ToString();
    //}

    //private void btnRegistrar_Click(object sender, EventArgs e)
    //{
    //    this.idFacturaRegistrado = this.registrarFactura();
    //    MessageBox.Show("Se registró con éxito la factura número " + this.idFacturaRegistrado);
    //    this.obtenerTiposClientes();
    //    if (idFacturaRegistrado != "")
    //    {
    //        this.gbTickets.Visible = true;
    //        this.gbFactura.Visible = false;
    //    } 
    //    else
    //    {
    //        this.gbTickets.Visible = false;
    //        this.gbFactura.Visible = true;
    //    }
    //}

    //private void cboFunciones_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (this.cboFunciones.SelectedIndex > 0)
    //    {
    //        this.obtenerSalas();
    //    }
    //}

    //private void btnRegistrarTicket_Click(object sender, EventArgs e)
    //{
    //    this.gbFactura.Visible = false;
    //    this.gbTickets.Visible = true;
    //    string funcionStr = this.cboFunciones.Text.ToString();
    //    string salaStr = this.cboSalas.Text.ToString();
    //    string butaca = this.cboButacasDisp.Text.ToString();
    //    string resultado = this.registrarTicket();

    //    if ( resultado != "OK")
    //    {
    //        MessageBox.Show(resultado);
    //    } 
    //    else
    //    {
    //        MessageBox.Show("TICKET FACTURA N°: " + this.idFacturaRegistrado + "\n" +
    //       "Se ha registrado los tickets para la película: " + funcionStr + "\n" +
    //       "Sala seleccionada: " + salaStr + "\n" +
    //       "Butaca seleccionada: " + butaca);
    //    }
    //}

    //private string registrarTicket()
    //{
    //    if(this.txPrecio.Text == "")
    //    {
    //        return "El precio no puede estar vacío";
    //    }
    //    SqlCommand cmd = new SqlCommand();
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@idFactura", Convert.ToInt32(this.idFacturaRegistrado));
    //    cmd.Parameters.AddWithValue("@idFuncion", this.cboFunciones.SelectedValue);
    //    cmd.Parameters.AddWithValue("@idButaca", this.cboButacasDisp.SelectedValue);
    //    cmd.Parameters.AddWithValue("@precio", Convert.ToDecimal(this.txPrecio.Text));
    //    cmd.Parameters.AddWithValue("@idTipoCliente", this.cboTipoCliente.SelectedValue);
    //    SqlParameter mensaje = new SqlParameter("@mensaje", SqlDbType.VarChar, 30)
    //    {
    //        Direction = ParameterDirection.Output
    //    };
    //    SqlParameter idFactura = new SqlParameter("@idFactura", SqlDbType.Int)
    //    {
    //        Direction = ParameterDirection.Output
    //    };
    //    cmd.Parameters.Add(mensaje);
    //    cmd.Parameters.Add(idFactura);
    //    DataTable result = ConsultasData.ejecutarSpParams("PA_REGISTRAR_TICKET", cmd);
    //    DataRow row = result.Rows[0];
    //    string status = row.ItemArray[0].ToString();
    //    this.idFactura = Convert.ToInt32(row.ItemArray[1]);
    //    PrintDocument pd = new PrintDocument();
    //    PrinterSettings ps = new PrinterSettings();
    //    pd.PrinterSettings = ps;
    //    pd.PrintPage += printDocument1_PrintPage;
    //    pd.DocumentName = "ticket-" + this.idFactura.ToString();
    //    pd.Print();
    //    return status;
    //}

    //private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    //{
    //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
    //    {
    //        e.Handled = true;
    //    }

    //    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
    //    {
    //        e.Handled = true;
    //    }
    //}

    //private void cboTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (tiposClientes.Count > 0)
    //    {
    //        decimal precio = tiposClientes.FirstOrDefault(o => o.idTipoCliente == this.cboTipoCliente.SelectedIndex + 1).precio;
    //        this.txPrecio.Text = precio.ToString();
    //    }

    //}


    //private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
    //{
    //    SqlCommand cmd = new SqlCommand();
    //    cmd.Parameters.AddWithValue("@idFactura", this.idFactura);
    //    DataTable impresion = ConsultasData.ejecutarSpParams("PA_IMPRIMIR_TICKET", cmd);
    //    string nombrePelicula = impresion.Rows[0].ItemArray[0].ToString();
    //    string fecha = impresion.Rows[0].ItemArray[1].ToString();
    //    int nroButaca = Convert.ToInt32(impresion.Rows[0].ItemArray[2]);
    //    int nroSala = Convert.ToInt32(impresion.Rows[0].ItemArray[3]);
    //    Font font = new Font("Arial", 20, FontStyle.Bold);
    //    Font fontTitulo = new Font("Arial", 24, FontStyle.Bold);
    //    e.Graphics.DrawString("CINEMA 15 - REPORTE", fontTitulo, Brushes.Black, new RectangleF(220, 10, 1000, 40));
    //    e.Graphics.DrawString("Ticket numero: " + this.idFactura.ToString(), font, Brushes.Black, new RectangleF(0, 50, 1000, 40));
    //    e.Graphics.DrawString("-------------------------------------------------", fontTitulo, Brushes.Black, new RectangleF(0, 80, 1000, 40));
    //    e.Graphics.DrawString("Pelicula: " + nombrePelicula, font, Brushes.Black, new RectangleF(0, 110, 1000, 40));
    //    e.Graphics.DrawString("Fecha de emisión: " + fecha, font, Brushes.Black, new RectangleF(0, 140, 1000, 40));
    //    e.Graphics.DrawString("Número de butaca: " + nroButaca.ToString(), font, Brushes.Black, new RectangleF(0, 170, 1000, 40));
    //    e.Graphics.DrawString("Número de sala: " + nroSala.ToString(), font, Brushes.Black, new RectangleF(0, 200, 1000, 40));
    //    e.Graphics.DrawString("-------------------------------------------------", fontTitulo, Brushes.Black, new RectangleF(0, 250, 1000, 40));
    //}


