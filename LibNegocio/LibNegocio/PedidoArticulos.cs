using LibData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LibNegocio
{
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

        //Constructor por defecto
        public PedidoArticulos()
        {

        }


        //Método para el ingreso del objeto en la capa de datos
        public PedidoArticulos ingresar()
        {
            PedidoArticulos objPedido_Articulo = new PedidoArticulos();

            //Método de ingreso desde lib data

            return objPedido_Articulo;
        }//Fin ingresar


        //Método para obtener los resultados desde la capa de dato
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


        public PedidoArticulos listarPorPedido(PedidoArticulos objPedidoArticulos)
        {
            try
            {
                BaseDato bd = new BaseDato();

                objPedidoArticulos = bd.listarPedidoArticulosPorPedido(objPedidoArticulos);


            }catch(Exception e)
            {
                objPedidoArticulos.Mensaje = e.Message;
            }


            return objPedidoArticulos;
        }


        //Método para generar la modificación desde la capa de dato
        public PedidoArticulos modificar()
        {
            PedidoArticulos objPedido_Articulo = new PedidoArticulos();

            //Método de ingreso desde lib data

            return objPedido_Articulo;
        }//Fin modificar


        //Método para generar la petición de borrado lógico en la capa de dato
        public PedidoArticulos eliminar()
        {
            PedidoArticulos objPedido_Articulo = new PedidoArticulos();

            //Método de ingreso desde lib data

            return objPedido_Articulo;
        }//Fin eliminar

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
