using LibData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LibNegocio
{
    /// <summary>
    /// Clase que contiene la logica de negocio entre para el acceso a la capa de datos
    /// </summary>
    public class PedidoArticulos
    {
        #region atributos
        long _id_pedido_articulos;
        int _id_pedido;
        int _id_articulo;
        string _tamano_articulo;
        string _color_articulo;
        int _unidades_articulo;
        int _precio_u_articulo;
        string _Mensaje;
        bool _exito;
        DataSet _ds = new DataSet();

        #endregion

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public PedidoArticulos()
        {

        }

        #region Metodos
        /// <summary>
        /// Método para el ingreso del objeto en la capa de datos 
        /// </summary>
        /// <param name="objPedidoArticulos"></param>
        /// <returns></returns>
        public PedidoArticulos ingresar(PedidoArticulos objPedidoArticulos)
        {
          try
            {
                BaseDato bd = new BaseDato();

                objPedidoArticulos = bd.ingresarPedidoArticulos(objPedidoArticulos);

            }
            catch (Exception e)
            {
                objPedidoArticulos.Mensaje = e.Message;
            }

            return objPedidoArticulos;
        }//Fin ingresar


        /// <summary>
        /// Método para obtener los resultados desde la capa de datos
        /// </summary>
        /// <param name="objPedidoArticulos"></param>
        /// <returns></returns>
        public PedidoArticulos listar(PedidoArticulos objPedidoArticulos)
        {
            try
            {
                BaseDato bd = new BaseDato();

                objPedidoArticulos = bd.listarPedidoArticulos(objPedidoArticulos);

            }
            catch (Exception e)
            {
                objPedidoArticulos.Mensaje = e.Message;
            }
            
            return objPedidoArticulos;
        }//Fin listar

        /// <summary>
        /// Método para obtener los datos desde la capa de datos segun IDPedido
        /// </summary>
        /// <param name="objPedidoArticulos"></param>
        /// <returns></returns>
        public PedidoArticulos listarPorPedido(PedidoArticulos objPedidoArticulos)
        {
            try
            {
                BaseDato bd = new BaseDato();

                objPedidoArticulos = bd.listarPedidoArticulosPorPedido(objPedidoArticulos);


            }
            catch (Exception e)
            {
                objPedidoArticulos.Mensaje = e.Message;
            }


            return objPedidoArticulos;
        }//Fin listarPorPedidos


        /// <summary>
        /// Método para listar los pedidos desde la capa de datos
        /// </summary>
        /// <param name="objPedidoArticulos"></param>
        /// <returns></returns>
        public PedidoArticulos listarPedidosListBox(PedidoArticulos objPedidoArticulos)
        {

            try
            {

                BaseDato bd = new BaseDato();

                objPedidoArticulos = bd.listarPedidosListBox(objPedidoArticulos);

            }
            catch (Exception e)
            {
                objPedidoArticulos.Mensaje = e.Message;
            }



            return objPedidoArticulos;
        }//Fin listarPedidosListBox



        /// <summary>
        /// Método para listar listar los articulos desde la capa de datos
        /// </summary>
        /// <param name="objPedidoArticulos"></param>
        /// <returns></returns>
        public PedidoArticulos listarArticulosDropList(PedidoArticulos objPedidoArticulos)
        {

            try
            {
                BaseDato bd = new BaseDato();

                objPedidoArticulos = bd.listaArticulosDropList(objPedidoArticulos);

            }
            catch (Exception e)
            {
                objPedidoArticulos.Mensaje = e.Message;
            }



            return objPedidoArticulos;
        }//Fin listarArticulosDropList



        /// <summary>
        /// Método para obtener los datos de los articulos desde la capa de datos
        /// </summary>
        /// <param name="objPedidoArticulos"></param>
        /// <returns></returns>
        public PedidoArticulos listarDatosArticulo(PedidoArticulos objPedidoArticulos)
        {

            try
            {
                BaseDato bd = new BaseDato();

                objPedidoArticulos = bd.listarDatosArticulo(objPedidoArticulos);

            }
            catch (Exception e)
            {
                objPedidoArticulos.Mensaje = e.Message;
            }

            return objPedidoArticulos;
        }//Fin listarDatosArticulos



        /// <summary>
        /// Método para generar la modificación desde la capa de dato
        /// </summary>
        /// <param name="objPedidoArticulos"></param>
        /// <returns></returns>
        public PedidoArticulos modificar(PedidoArticulos objPedidoArticulos)
        {
            try
            {
                BaseDato bd = new BaseDato();

                objPedidoArticulos = bd.modificarPedidoArticulos(objPedidoArticulos);
            }
            catch(Exception e)
            {
                objPedidoArticulos.Mensaje = e.Message;
            }

            return objPedidoArticulos;

        }//Fin modificar


        /// <summary>
        /// Método para generar la petición de borrado lógico en la capa de dato
        /// </summary>
        /// <param name="objPedidoArticulos"></param>
        /// <returns></returns>
        public PedidoArticulos eliminar(PedidoArticulos objPedidoArticulos)
        {
            try
            {
                BaseDato bd = new BaseDato();

                objPedidoArticulos = bd.eliminarPedidoArticulos(objPedidoArticulos);
            }
            catch (Exception e)
            {
                objPedidoArticulos.Mensaje = e.Message;
            }

            return objPedidoArticulos;
        }//Fin eliminar


        #endregion


        #region getters & setters
        public long Id_pedido_articulos
        {
            get
            {
                return _id_pedido_articulos;
            }

            set
            {
                _id_pedido_articulos = value;
            }
        }

        public int Id_pedido
        {
            get
            {
                return _id_pedido;
            }

            set
            {
                _id_pedido = value;
            }
        }

        public int Id_articulo
        {
            get
            {
                return _id_articulo;
            }

            set
            {
                _id_articulo = value;
            }
        }

        public string Tamano_articulo
        {
            get
            {
                return _tamano_articulo;
            }

            set
            {
                _tamano_articulo = value;
            }
        }

        public string Color_articulo
        {
            get
            {
                return _color_articulo;
            }

            set
            {
                _color_articulo = value;
            }
        }

        public int Unidades_articulo
        {
            get
            {
                return _unidades_articulo;
            }

            set
            {
                _unidades_articulo = value;
            }
        }

        public int Precio_u_articulo
        {
            get
            {
                return _precio_u_articulo;
            }

            set
            {
                _precio_u_articulo = value;
            }
        }

        public string Mensaje
        {
            get
            {
                return _Mensaje;
            }

            set
            {
                _Mensaje = value;
            }
        }

        public DataSet Ds
        {
            get
            {
                return _ds;
            }

            set
            {
                _ds = value;
            }
        }

        public bool Exito
        {
            get
            {
                return _exito;
            }

            set
            {
                _exito = value;
            }
        }


        #endregion
    }//Fin Class

}//Fin Namespace
