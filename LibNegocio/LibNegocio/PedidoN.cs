using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LibData;

namespace LibNegocio
{
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

        #region Propiedades
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

        #region getter and setter
        //metodo ingresar pedido
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

        //metodo listar pedido
        public PedidoN listarPedido(PedidoN objPedido)
        {
            BaseDato objDB = new BaseDato();
            objPedido = objDB.listarPedido(objPedido);

            return objPedido;
        }//fin metodo listar

        //metodo listar Cliente
        public PedidoN listarCliente(PedidoN objCliente)
        {
            BaseDato objDB = new BaseDato();
            objCliente = objDB.listarCliente(objCliente);

            return objCliente;
        }//fin metodo listar Cliente

        //metodo listar Vendedor
        public PedidoN listarVendedor(PedidoN objVendedor)
        {
            BaseDato objDB = new BaseDato();
            objVendedor = objDB.listarVendedor(objVendedor);

            return objVendedor;
        }//fin metodo listar Vendedor

        //metodo modificar
        public PedidoN modificarPedido(PedidoN objPedido)
        {
            BaseDato objDB = new BaseDato();
            objPedido = objDB.modificarPedido(objPedido);

            return objPedido;
        }//fin metodo modificar
        
        //metodo eliminar
        public PedidoN eliminar(PedidoN objPedido)
        {
            BaseDato objDB = new BaseDato();
            objPedido = objDB.eliminarPedido(objPedido);

            return objPedido;
        }//fin metodo eliminar
        #endregion

    }//fin class
}//fin namespace
