using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verduleria
{
    public partial class VerVentas : Form
    {
        public VerVentas()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            
            Form1 miForm = new Form1();
            miForm.Show();
        }

        private void VerVentas_Load(object sender, EventArgs e)
        {
            traerVentas();
        }
        private void traerVentas()
        {
            //DataSet ds = new DataSet();
            //SqlConnection conn = new SqlConnection(Properties.Settings.Default.miConexion);
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "select * from ventas order by fecha desc";
            //cmd.Connection = conn;


            //try
            //{
            //    conn.Open();
            //    ds = cmd.ExecuteDataSet();

            //    listBoxProductos.DataSource = lsproductosDesc; // es el fuente que alimentara el listbox
            //}
            //catch (Exception ex)
            //{
            //    lblMensaje.Text = "Error al conectar a la base de datos : " + ex.Message;
            //}
            SqlConnection nwindConn = new SqlConnection(Properties.Settings.Default.miConexion);
            try
            {
               
                SqlCommand selectCMD = new SqlCommand("select * from ventas order by fecha desc", nwindConn);
                //selectCMD.CommandTimeout = 30; // eso es el tiempo max que aguan,ta la base de dato
                SqlDataAdapter customerDA = new SqlDataAdapter();
                customerDA.SelectCommand = selectCMD;
                nwindConn.Open();
                DataSet customerDS = new DataSet();
                customerDA.Fill(customerDS, "Ventas");
                dgvventas.DataSource = customerDS.Tables[0];
                nwindConn.Close();

            }
            catch (Exception ex)
            {
               MessageBox.Show( "Error al conectar a la base de datos : " + ex.Message);
                nwindConn.Close();
            }
           
         
        }


    }
}
