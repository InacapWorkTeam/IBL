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



    }
}
