using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using LibNegocio;


namespace LibData
{
    public class BaseDato
    {
        string strConn = ConfigurationManager.AppSettings["strConn"];

        //Inicio metodo ingresar Pedidos
        public Pedido ingresarPedido(Pedido objPedido)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_ingresarPedido";
                
                cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = objPedido.Fecha;
                cmd.Parameters.Add("@Total", SqlDbType.Int).Value = objPedido.Total;
                cmd.Parameters.Add("@id_vendedor", SqlDbType.Int).Value = objPedido.Id_vendedor;
                cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = objPedido.Id_cliente;
                
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                objPedido.Exito = true;


            }
            catch (Exception ex)
            {
                objPedido.Exito = false;
                objPedido.Mensaje = "Excepcion capturada:  " + ex.Message;
            }
            return objPedido;
        }//Fin metodo ingresar pedido

        //Inicio metodo listar pedido
        public Pedido listarPedido(Pedido objPedido)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_listarPedido";

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = objPedido.Id_pedido;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda.Fill(objPedido.Ds);     //llenamos el dataset
                cmd.Connection.Close();
                objPedido.Exito = true;

            }
            catch (Exception ex)
            {
                objPedido.Exito = false;
                objPedido.Mensaje = "Excepcion capturada:   " + ex.Message;
            }
            return objPedido;
        }//Fin metodo listar pedido

        //Inicio metodo modificar pedido
        public Pedido modificarPedido(Pedido objPedido)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_modificarxId";

                cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = objPedido.Fecha;
                cmd.Parameters.Add("@Total", SqlDbType.Int).Value = objPedido.Total;
                cmd.Parameters.Add("@id_vendedor", SqlDbType.Int).Value = objPedido.Id_vendedor;
                cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = objPedido.Id_cliente;


                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                objPedido.Exito = true;
            }
            catch (Exception ex)
            {
                objPedido.Exito = false;
                objPedido.Mensaje = "Excepcion capturada:   " + ex.Message;
            }
            return objPedido;
        }//Fin metodo modificar pedido

        //Inicio metodo eliminar logico pedido
        public Pedido eliminarPedido(Pedido objPedido)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_eliminarxId";

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = objPedido.Id_pedido;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                objPedido.Exito = true;
            }
            catch (Exception ex)
            {
                objPedido.Exito = false;
                objPedido.Mensaje = "Excepcion capturada:   " + ex.Message;
            }
            return objPedido;
        }//Fin metodo eliminar logico pedido


        #region Pedido_Articulos

        public PedidoArticulos listarPedidoArticulos(PedidoArticulos objPedidoArticulos)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_listarPedidoArticulos";

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = objPedidoArticulos.Id_pedido_articulos;
              //  cmd.Parameters.Add("@id_pedido", SqlDbType.Int).Value = 0;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda.Fill(objPedidoArticulos.Ds);
                cmd.Connection.Close();
                objPedidoArticulos.Exito = true;

            }
            catch (Exception ex)
            {
                objPedidoArticulos.Exito = false;
                objPedidoArticulos.Mensaje = "Excepcion capturada:   " + ex.Message;
            }

            return objPedidoArticulos;
        }

        public PedidoArticulos listarPedidoArticulosPorPedido(PedidoArticulos objPedidoArticulos)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_listarPedidoArticulosPorPedido";

                cmd.Parameters.Add("@id_pedido", SqlDbType.Int).Value = objPedidoArticulos.Id_pedido;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda.Fill(objPedidoArticulos.Ds);
                cmd.Connection.Close();
                objPedidoArticulos.Exito = true;

            }
            catch (Exception ex)
            {
                objPedidoArticulos.Exito = false;
                objPedidoArticulos.Mensaje = "Excepcion capturada:   " + ex.Message;
            }

            return objPedidoArticulos;
        }

        public PedidoArticulos listarPedidosListBox(PedidoArticulos objPedidoArticulos)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_listarPedidos";

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda.Fill(objPedidoArticulos.Ds);
                cmd.Connection.Close();
                objPedidoArticulos.Exito = true;

            }
            catch (Exception ex)
            {
                objPedidoArticulos.Exito = false;
                objPedidoArticulos.Mensaje = "Excepcion capturada:   " + ex.Message;
            }

            return objPedidoArticulos;
        }

        public PedidoArticulos listaArticulosDropList(PedidoArticulos objPedidoArticulos)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_listarArticulos";

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda.Fill(objPedidoArticulos.Ds);
                cmd.Connection.Close();
                objPedidoArticulos.Exito = true;

            }
            catch (Exception ex)
            {
                objPedidoArticulos.Exito = false;
                objPedidoArticulos.Mensaje = "Excepcion capturada:   " + ex.Message;
            }

            return objPedidoArticulos;
        }


        public PedidoArticulos listarDatosArticulo(PedidoArticulos objPedidoArticulos)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_listarDatosArticulo";
                cmd.Parameters.Add("@id_articulo", SqlDbType.Int).Value = objPedidoArticulos.Id_articulo;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda.Fill(objPedidoArticulos.Ds);
                cmd.Connection.Close();
                objPedidoArticulos.Exito = true;

            }
            catch (Exception ex)
            {
                objPedidoArticulos.Exito = false;
                objPedidoArticulos.Mensaje = "Excepcion capturada:   " + ex.Message;
            }

            return objPedidoArticulos;
        }

        #endregion


    }
}
