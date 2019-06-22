using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LibData;

namespace LibNegocio
{
    public class Pedido
    {
        #region Atributos
        DateTime fecha;
        int total;
        int id_vendedor;
        int id_cliente;
        bool estado;
        #endregion

        #region Propiedades
        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public int Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public int Id_vendedor
        {
            get
            {
                return id_vendedor;
            }

            set
            {
                id_vendedor = value;
            }
        }

        public int Id_cliente
        {
            get
            {
                return id_cliente;
            }

            set
            {
                id_cliente = value;
            }
        }

        public bool Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public Pedido(DateTime fecha, int total, int id_vendedor, int id_cliente, bool estado)
        {
            this.Fecha = fecha;
            this.Total = total;
            this.Id_vendedor = id_vendedor;
            this.Id_cliente = id_cliente;
            this.Estado = estado;
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
