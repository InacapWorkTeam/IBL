using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using LibNegocio;

namespace LibData
{
    /// <summary>
    /// Clase que contiene la lógica de acceso la base de datos 
    /// </summary>
    public class BaseDato
    {
        //Se obtienen los detalles de la conexión a la base de datos desde el archivo de configuración del ejecutable
        string strConn = ConfigurationManager.AppSettings["strConn"];

        #region Pedido
        
        //Inicio metodo ingresar Pedidos
        public PedidoN ingresarPedido(PedidoN objPedido)
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
        public PedidoN listarPedido(PedidoN objPedido)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_listarPedido";

                cmd.Parameters.Add("@id_pedido", SqlDbType.Int).Value = objPedido.Id_pedido;

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

        //Inicio metodo listar Clientes
        public PedidoN listarCliente(PedidoN objPedido)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_listarCliente";

                //cmd.Parameters.Add("@Id", SqlDbType.Int).Value = objPedido.Id_pedido;

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
        }//Fin metodo listar Clientes

        //Inicio metodo listar Vendedores
        public PedidoN listarVendedor(PedidoN objPedido)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_listarVendedor";

                //cmd.Parameters.Add("@Id", SqlDbType.Int).Value = objPedido.Id_pedido;

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
        }//Fin metodo listar Vendedores

        //Inicio metodo modificar pedido
        public PedidoN modificarPedido(PedidoN objPedido)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_modificarPedido";

                cmd.Parameters.Add("@id_pedido", SqlDbType.Int).Value = objPedido.Id_pedido;
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
        public PedidoN eliminarPedido(PedidoN objPedido)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_eliminarPedido";

                cmd.Parameters.Add("@id_pedido", SqlDbType.Int).Value = objPedido.Id_pedido;

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

        #endregion

        #region Pedido_Articulos

        /// <summary>
        /// Método para obtener los registros de la tabla Pedido_Articulos
        /// </summary>
        /// <param name="objPedidoArticulos"> Un objeto PedidoArticulos con los datos necesarios para el procedimiento almacenado </param>
        /// <returns> Un objeto PedidoArticulos con los datos de la consulta y confirmación del procedimiento </returns>
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
        }//Fin listarPedidoArticulos


        /// <summary>
        /// Método que obtiene los registros de la tabla Pedido_Articulos según ID_Pedido
        /// </summary>
        /// <param name="objPedidoArticulos"> Un objeto PedidoArticulos con los datos necesarios para el procedimiento almacenado </param>
        /// <returns> Un objeto PedidoArticulos con los datos de la consulta y confirmación del procedimiento </returns>
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
        }//Fin listarPedidoArticulosPorPedido


        /// <summary>
        /// Método para recuperar pedidos
        /// </summary>
        /// <param name="objPedidoArticulos"> Un objeto PedidoArticulos con los datos necesarios para el procedimiento almacenado </param>
        /// <returns> Un objeto PedidoArticulos con los datos de la consulta y confirmación del procedimiento </returns>
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
        }//Fin listarPedidosListBox


        /// <summary>
        /// Método para recuperar Articulos
        /// </summary>
        /// <param name="objPedidoArticulos"> Un objeto PedidoArticulos con los datos necesarios para el procedimiento almacenado </param>
        /// <returns> Un objeto PedidoArticulos con los datos de la consulta y confirmación del procedimiento </returns>
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
        }//Fin listaArticulosDropList


        /// <summary>
        /// Método para recuperar los datos de un Articulo
        /// </summary>
        /// <param name="objPedidoArticulos"> Un objeto PedidoArticulos con los datos necesarios para el procedimiento almacenado </param>
        /// <returns> Un objeto PedidoArticulos con los datos de la consulta y confirmación del procedimiento </returns>
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
        }//Fin listarDatosArticulo



        /// <summary>
        /// Método para ingresar un registro en la tabla Pedido_Articulos
        /// </summary>
        /// <param name="objPedidoArticulos"> Un objeto PedidoArticulos con los datos necesarios para el procedimiento almacenado </param>
        /// <returns> Un objeto PedidoArticulos con los datos de la consulta y confirmación del procedimiento </returns>
        public PedidoArticulos ingresarPedidoArticulos(PedidoArticulos objPedidoArticulos)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_ingresarPedidoArticulo";
                cmd.Parameters.Add("@id_pedido", SqlDbType.Int).Value = objPedidoArticulos.Id_pedido;
                cmd.Parameters.Add("@id_articulo", SqlDbType.Int).Value = objPedidoArticulos.Id_articulo;
                cmd.Parameters.Add("@tamano_articulo", SqlDbType.VarChar).Value = objPedidoArticulos.Tamano_articulo;
                cmd.Parameters.Add("@color_articulo", SqlDbType.VarChar).Value = objPedidoArticulos.Color_articulo;
                cmd.Parameters.Add("@unidades_articulo", SqlDbType.Int).Value = objPedidoArticulos.Unidades_articulo;
                cmd.Parameters.Add("@precio_u_articulo", SqlDbType.Int).Value = objPedidoArticulos.Precio_u_articulo;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                cmd.Connection.Close();
                objPedidoArticulos.Exito = true;

            }
            catch (Exception ex)
            {
                objPedidoArticulos.Exito = false;
                objPedidoArticulos.Mensaje = "Excepcion capturada:   " + ex.Message;
            }

            return objPedidoArticulos;
        }//Fin ingresarPedidoArticulos



        /// <summary>
        /// Metodo para modificar registro en la tabla Pedido_Articulos
        /// </summary>
        /// <param name="objPedidoArticulos"> Un objeto PedidoArticulos con los datos necesarios para el procedimiento almacenado </param>
        /// <returns> Un objeto PedidoArticulos con los datos de la consulta y confirmación del procedimiento </returns>
        public PedidoArticulos modificarPedidoArticulos(PedidoArticulos objPedidoArticulos)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_modificarPedidoArticulo";

                cmd.Parameters.Add("@id_pedido_articulo", SqlDbType.Int).Value = objPedidoArticulos.Id_pedido_articulos;
                cmd.Parameters.Add("@id_pedido", SqlDbType.Int).Value = objPedidoArticulos.Id_pedido;
                cmd.Parameters.Add("@id_articulo", SqlDbType.Int).Value = objPedidoArticulos.Id_articulo;
                cmd.Parameters.Add("@tamano_articulo", SqlDbType.VarChar).Value = objPedidoArticulos.Tamano_articulo;
                cmd.Parameters.Add("@color_articulo", SqlDbType.VarChar).Value = objPedidoArticulos.Color_articulo;
                cmd.Parameters.Add("@unidades_articulo", SqlDbType.Int).Value = objPedidoArticulos.Unidades_articulo;
                cmd.Parameters.Add("@precio_u_articulo", SqlDbType.Int).Value = objPedidoArticulos.Precio_u_articulo;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                cmd.Connection.Close();
                objPedidoArticulos.Exito = true;

            }
            catch (Exception ex)
            {
                objPedidoArticulos.Exito = false;
                objPedidoArticulos.Mensaje = "Excepcion capturada:   " + ex.Message;
            }

            return objPedidoArticulos;
        }//Fin modificarPedidoArticulos


        /// <summary>
        /// Método para realizar un borrado lógico de un registro de la tabla Pedido_Articulos
        /// </summary>
        /// <param name="objPedidoArticulos"> Un objeto PedidoArticulos con los datos necesarios para el procedimiento almacenado </param>
        /// <returns> Un objeto PedidoArticulos con los datos de la consulta y confirmación del procedimiento </returns>
        public PedidoArticulos eliminarPedidoArticulos(PedidoArticulos objPedidoArticulos)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_eliminarPedidoArticulos";

                cmd.Parameters.Add("@id_pedido_articulos", SqlDbType.Int).Value = objPedidoArticulos.Id_pedido_articulos;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                cmd.Connection.Close();
                objPedidoArticulos.Exito = true;

            }
            catch (Exception ex)
            {
                objPedidoArticulos.Exito = false;
                objPedidoArticulos.Mensaje = "Excepcion capturada:   " + ex.Message;
            }

            return objPedidoArticulos;
        }//Fin eliminarPedidoArticulos

        #endregion

        
        #region Articulos
        //metodo ingresar articulo
        public Articulo ingresarArticulo(Articulo objArticulo)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_ingresarArticulo";

                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 20).Value = objArticulo.Nombre;
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 200).Value = objArticulo.Descripcion;
                cmd.Parameters.Add("@color", SqlDbType.VarChar, 20).Value = objArticulo.Color;
                cmd.Parameters.Add("@tamaño", SqlDbType.VarChar, 10).Value = objArticulo.Tamaño;
                cmd.Parameters.Add("@precio", SqlDbType.Int).Value = objArticulo.Precio;
                cmd.Parameters.Add("@coste_u_mayorista", SqlDbType.Int).Value = objArticulo.Coste_u_mayorista;
                cmd.Parameters.Add("@unidades", SqlDbType.Int).Value = objArticulo.Unidades;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                objArticulo.Exito = true;
            }
            catch (Exception ex)
            {
                objArticulo.Exito = false;
                objArticulo.Mensaje = "Excepcion capturada:  " + ex.Message;
            }//fin try-catch

            return objArticulo;
        }
        //fin ingresar
        //metodo listar articulo
        public Articulo listarArticulo(Articulo objArticulo)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_listarArticulo";

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda.Fill(objArticulo.Data);
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                objArticulo.Mensaje = "Excepcion capturada:  " + ex.Message;
            }

            return objArticulo;
        }
        //fin listar
        //metodo actualizar articulo
        public Articulo actualizarArticulo(Articulo objArticulo)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_actualizarArticulo";

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = objArticulo.Id;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 20).Value = objArticulo.Nombre;
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 200).Value = objArticulo.Descripcion;
                cmd.Parameters.Add("@color", SqlDbType.VarChar, 20).Value = objArticulo.Color;
                cmd.Parameters.Add("@tamaño", SqlDbType.VarChar, 10).Value = objArticulo.Tamaño;
                cmd.Parameters.Add("@precio", SqlDbType.Int).Value = objArticulo.Precio;
                cmd.Parameters.Add("@coste_u_mayorista", SqlDbType.Int).Value = objArticulo.Coste_u_mayorista;
                cmd.Parameters.Add("@unidades", SqlDbType.Int).Value = objArticulo.Unidades;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                objArticulo.Exito = true;
            }
            catch (Exception ex)
            {
                objArticulo.Exito = false;
                objArticulo.Mensaje = "Excepcion capturada:  " + ex.Message;
            }//fin try-catch

            return objArticulo;
        }
        //fin actualizar
        //metodoeliminar articulo
        public Articulo eliminarArticulo(Articulo objArticulo)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_eliminar";

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = objArticulo.Id;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                objArticulo.Exito = true;
            }
            catch (Exception ex)
            {
                objArticulo.Exito = false;
                objArticulo.Mensaje = "Excepcion capturada:  " + ex.Message;
            }
            return objArticulo;
        }
        //fin eliminar
        #endregion
    
    }
}
