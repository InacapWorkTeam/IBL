﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LibData;

namespace LibNegocio
{
    public class Pedido
    {
        #region Atributos
        int _id_pedido;
        string _mensaje;
        DateTime _fecha;
        bool _exito = false;
        int _total;
        int _id_vendedor;
        int _id_cliente;
        bool _estado;
        DataSet _ds = new DataSet();
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
        public Pedido(DateTime _fecha, int _total, int _id_vendedor, int _id_cliente, bool _estado)
        {
            this._fecha = _fecha;
            this._total = _total;
            this._id_vendedor = _id_vendedor;
            this._id_cliente = _id_cliente;
            this._estado = _estado;
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

        public Pedido(int _id_pedido)
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
        #endregion


        //metodo ingresar pedido
        public Pedido ingresarPedido(Pedido objPedido)
        {
            BaseDato objDB = new BaseDato();
            objPedido = objPedido.ingresarPedido(objPedido);

            return objPedido;
        }//fin metodo ingresar

        //metodo listar pedido
        public Pedido listarPedido(Pedido objPedido)
        {
            BaseDato objDB = new BaseDato();
            objPedido = objDB.listarPedido(objPedido);

            return objPedido;
        }//fin metodo listar

        //metodo modificar
        public Pedido modificarPedido(Pedido objPedido)
        {
            BaseDato objDB = new BaseDato();
            objPedido = objDB.modificarPedido(objPedido);

            return objPedido;
        }//fin metodo modificar
        
        //metodo eliminar
        public Pedido eliminar(Pedido objPedido)
        {
            BaseDato objDB = new BaseDato();
            objPedido = objDB.eliminarPedido(objPedido);

            return objPedido;
        }//fin metodo eliminar

    }//fin class
}//fin namespace
