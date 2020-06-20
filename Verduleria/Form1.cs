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

namespace Verduleria
{
    public partial class Form1 : Form
    {
        List<Productos> lsProducto = new List<Productos>();
        List<String> lsproductosDesc = new List<string>();
        List<Ventas> lsVentas = new List<Ventas>();
        double precioProducto = 0;
        double Nuevototal = 0;
        string idProd = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarListBoxProductos();
        }
        private void cargarListBoxProductos()
        {
            
            SqlDataReader dr;
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.miConexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText="select * from productos";
            cmd.Connection = conn;

            try
            {
                conn.Open();
                dr= cmd.ExecuteReader();
                while (dr.Read())
                {
                    Productos prod = new Productos();
                    prod.descripcion = dr["Descripcion"].ToString();//este  tostring permite convertir a String
                    prod.IdProducto = dr["idProducto"].ToString();
                    prod.fechaViencimiento = Convert.ToDateTime(dr["FechaVencimiento"]);// este convert permite convertir a datetime
                    prod.origen = dr["Origen"].ToString();
                    prod.precio = Convert.ToDouble(dr["Precio"].ToString());
                    prod.cantidad = Convert.ToInt32(dr["Cantidad"].ToString());

                    lsProducto.Add(prod);
                    lsproductosDesc.Add(prod.descripcion);

                }
                listBoxProductos.Items.Clear(); // es para limpiar el listbox
                listBoxProductos.DataSource = lsproductosDesc; // es el fuente que alimentara el listbox
            }
            catch(Exception ex)
            {
                lblMensaje.Text = "Error al conectar a la base de datos : " + ex.Message;
            }

}
        private void listBoxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Ventas miVenta = new Ventas();
            miVenta.cantidad = Convert.ToInt32(txtCantidad.Text);
           
            miVenta.descuento = txtdescuento.Text;
            miVenta.fecha = DateTime.Now;
            miVenta.Idcliente = "";
            miVenta.idProducto = idProd;
            miVenta.monto = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtPrecioUnitario.Text);
            miVenta.tipoVenta = "";

            lsVentas.Add(miVenta);

            listboxCarrito.DataSource = lsVentas;
            listboxCarrito.DisplayMember = "fecha";
            listboxCarrito.DisplayMember = "idProducto";

            Nuevototal = Nuevototal + miVenta.monto;


            lblTotal.Text = "";
            lblTotal.Text = Nuevototal.ToString();


            txtBuscar.Text = "";
            txtCantidad.Text = "";
            txtdescuento.Text = "";
            txtPrecioUnitario.Text = "";
            btnFinalizar.Enabled = true;

            
        }

        private void listboxCarrito_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

            if (lsVentas.Count >= 0)
            {
                foreach(Ventas obj in lsVentas)
                {
                    SqlConnection conn = new SqlConnection(Properties.Settings.Default.miConexion);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "insert into ventas (Cantidad,Monto, TipoVenta,Idcliente, Fecha,IdProducto,Descuento) values (@Cantidad,@Monto, @TipoVenta,@Idcliente, @Fecha,@IdProducto,@Descuento) ";
                    cmd.Connection = conn;
                    //SqlParameter param = new SqlParameter("@Desc", SqlDbType.VarChar);
                    //param.Value = txtBuscar.Text;

                    cmd.Parameters.AddWithValue("@Descuento", obj.descuento);
                    cmd.Parameters.AddWithValue("@Cantidad", obj.cantidad);
                    cmd.Parameters.AddWithValue("@Monto", obj.monto);
                    cmd.Parameters.AddWithValue("@TipoVenta", obj.tipoVenta);
                    cmd.Parameters.AddWithValue("@Idcliente", obj.Idcliente);
                    cmd.Parameters.AddWithValue("@Fecha", obj.fecha);
                    cmd.Parameters.AddWithValue("@IdProducto", obj.idProducto);
                    
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error al insertar ventad en la db" + ex.Message);
                    }
                }
               
               
                
            }
            
            VerVentas miForm = new VerVentas();
            miForm.Show();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                listBoxProductos.DataSource = null; // es para limpiar el listbox
                lsProducto.Clear();
                lsproductosDesc.Clear();
                SqlDataReader dr;
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.miConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from productos where Descripcion like @Desc";
                cmd.Connection = conn;
                //SqlParameter param = new SqlParameter("@Desc", SqlDbType.VarChar);
                //param.Value = txtBuscar.Text;

                cmd.Parameters.AddWithValue("@Desc", "%" + txtBuscar.Text + "%");
                //cmd.Parameters.Add(param);

                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Productos prod = new Productos();
                        prod.descripcion = dr["Descripcion"].ToString();//este  tostring permite convertir a String
                        prod.IdProducto = dr["idProducto"].ToString();
                        prod.fechaViencimiento = Convert.ToDateTime(dr["FechaVencimiento"]);// este convert permite convertir a datetime
                        prod.origen = dr["Origen"].ToString();
                        prod.precio = Convert.ToDouble(dr["Precio"].ToString());
                        prod.cantidad = Convert.ToInt32(dr["Cantidad"].ToString());

                        lsProducto.Add(prod);
                        lsproductosDesc.Add(prod.descripcion);

                    }
                   
                    listBoxProductos.DataSource = lsproductosDesc; // es el fuente que alimentara el listbox
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error al conectar a la base de datos : " + ex.Message;
                }
            }
            else
            {
                MessageBox.Show("Por favor ingresa un palabar para buscar");            }
           

        }

        private void listBoxProductos_Click(object sender, EventArgs e)
        {
           
            
            string nombreProd = listBoxProductos.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(nombreProd))
            {
                foreach(Productos prod in lsProducto)
                {
                    if(prod.descripcion== nombreProd)
                    {
                        idProd = prod.IdProducto;
                        precioProducto = prod.precio;
                        break;
                    }

                }
                txtPrecioUnitario.Text = precioProducto.ToString();
                txtCantidad.Text = "1";
                //double total = precioProducto * Convert.ToDouble(txtCantidad.Text);
                //lblTotal.Text = total.ToString();
            }


        }

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
          

            
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (!string.IsNullOrEmpty(txtCantidad.Text))
            //    {
            //        double total = precioProducto * Convert.ToDouble(txtCantidad.Text);
            //        lblTotal.Text = total.ToString();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Por favor ingresa una cantidad");
            //    }
            //}
        }

        private void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
