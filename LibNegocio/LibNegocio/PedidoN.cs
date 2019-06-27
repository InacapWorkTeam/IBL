using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LibData;

namespace LibNegocio
{
    /// <summary>
    /// Clase que contiene la logica de negocio para conectar con la capa de datos para Pedido
    /// </summary>
    public class PedidoN
    {
        #region Atributos
        //Variables para datos de pedido
        int _id_pedido;
        string _mensaje;
        DateTime _fecha;
        bool _exito = false;
        int _total;
        int _id_vendedor;
        int _id_cliente;
        bool _estado;
        DataSet _ds = new DataSet();

        //Variables para obtener nombres de cliente y vendedor asociado
        int _nombreCliente;
        int _nombreVendedor;
        #endregion


        public PedidoN(DateTime _fecha, int _total, int _id_vendedor, int _id_cliente, bool _estado)
        {
            this._fecha = _fecha;
            this._total = _total;
            this._id_vendedor = _id_vendedor;
            this._id_cliente = _id_cliente;
            this._estado = _estado;
        }

        public PedidoN()
        {

        }


        #region Metodos

        /// <summary>
        /// metodo ingresar pedido
        /// </summary>
        /// <param name="objPedido"></param>
        /// <returns></returns>
        public PedidoN ingresarPedido(PedidoN objPedido)
        {
            try
            {
                BaseDato objDB = new BaseDato();
                objPedido = objDB.ingresarPedido(objPedido);
            }
            catch(Exception e)
            {
                objPedido.Mensaje = e.Message;
            }
           

            return objPedido;
        }//fin metodo ingresar

        /// <summary>
        /// metodo listar pedido
        /// </summary>
        /// <param name="objPedido"></param>
        /// <returns></returns>
        public PedidoN listarPedido(PedidoN objPedido)
        {
            try
            {
                BaseDato objDB = new BaseDato();
            objPedido = objDB.listarPedido(objPedido);
            }
            catch (Exception e)
            {
                objPedido.Mensaje = e.Message;
            }
            return objPedido;
        }//fin metodo listar

        /// <summary>
        /// metodo listar Cliente
        /// </summary>
        /// <param name="objCliente"></param>
        /// <returns></returns>
        public PedidoN listarCliente(PedidoN objCliente)
        {
            try { 
            BaseDato objDB = new BaseDato();
            objCliente = objDB.listarCliente(objCliente);
            }
            catch (Exception e)
            {
                objCliente.Mensaje = e.Message;
            }
            return objCliente;
        }//fin metodo listar Cliente

        /// <summary>
        /// metodo listar Vendedor
        /// </summary>
        /// <param name="objVendedor"></param>
        /// <returns></returns>
        public PedidoN listarVendedor(PedidoN objVendedor)
        {
            try { 
            BaseDato objDB = new BaseDato();
            objVendedor = objDB.listarVendedor(objVendedor);
            }
            catch (Exception e)
            {
                objVendedor.Mensaje = e.Message;
            }
            return objVendedor;
        }//fin metodo listar Vendedor

        /// <summary>
        /// metodo modificar
        /// </summary>
        /// <param name="objPedido"></param>
        /// <returns></returns>
        public PedidoN modificarPedido(PedidoN objPedido)
        {
            try { 
            BaseDato objDB = new BaseDato();
            objPedido = objDB.modificarPedido(objPedido);
            }
            catch (Exception e)
            {
                objPedido.Mensaje = e.Message;
            }
            return objPedido;
        }//fin metodo modificar

        /// <summary>
        /// metodo eliminar
        /// </summary>
        /// <param name="objPedido"></param>
        /// <returns></returns>
        public PedidoN eliminar(PedidoN objPedido)
        {
            try { 
            BaseDato objDB = new BaseDato();
            objPedido = objDB.eliminarPedido(objPedido);
            }
            catch (Exception e)
            {
                objPedido.Mensaje = e.Message;
            }
            return objPedido;
        }//fin metodo eliminar
        #endregion


        #region getters & setters
        public string Mensaje
        {
            get
            {
                return _mensaje;
            }

            set
            {
                _mensaje = value;
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

        public PedidoN(int _id_pedido)
        {
            this._id_pedido = _id_pedido;
        }

        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }

            set
            {
                _fecha = value;
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

        public int Total
        {
            get
            {
                return _total;
            }

            set
            {
                _total = value;
            }
        }

        public int Id_vendedor
        {
            get
            {
                return _id_vendedor;
            }

            set
            {
                _id_vendedor = value;
            }
        }

        public int Id_cliente
        {
            get
            {
                return _id_cliente;
            }

            set
            {
                _id_cliente = value;
            }
        }

        public bool Estado
        {
            get
            {
                return _estado;
            }

            set
            {
                _estado = value;
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

        public int NombreCliente
        {
            get
            {
                return _nombreCliente;
            }

            set
            {
                _nombreCliente = value;
            }
        }

        public int NombreVendedor
        {
            get
            {
                return _nombreVendedor;
            }

            set
            {
                _nombreVendedor = value;
            }
        }
        #endregion


    }//fin class
}//fin namespace
