﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LibNegocio
{
    public class Articulo
    {
        #region Atributos
        int _id;
        string _nombre;
        string _descripcion;
        string _color;
        string _tamaño;
        int _precio;
        int _coste_u_mayorista;
        int _unidades;
        DataSet _Data = new DataSet();
        bool _exito = false;
        bool _Eliminado = true;
        string _mensaje;
        #endregion

        #region Get and Set
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                _descripcion = value;
            }
        }

        public string Color
        {
            get
            {
                return _color;
            }

            set
            {
                _color = value;
            }
        }

        public string Tamaño
        {
            get
            {
                return _tamaño;
            }

            set
            {
                _tamaño = value;
            }
        }

        public int Precio
        {
            get
            {
                return _precio;
            }

            set
            {
                _precio = value;
            }
        }

        public int Coste_u_mayorista
        {
            get
            {
                return _coste_u_mayorista;
            }

            set
            {
                _coste_u_mayorista = value;
            }
        }

        public int Unidades
        {
            get
            {
                return _unidades;
            }

            set
            {
                _unidades = value;
            }
        }

        public DataSet Data
        {
            get
            {
                return _Data;
            }

            set
            {
                _Data = value;
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

        public bool Eliminado
        {
            get
            {
                return _Eliminado;
            }

            set
            {
                _Eliminado = value;
            }
        }

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
        #endregion

        #region Constructores
        //Ingresar nuevo articulo
        public Articulo ingresarArticulo(Articulo objArticulo)
        {
            //BaseDatos objDB = new BaseDatos();
            //objServTecnico = objDB.ingresar(objServTecnico);

            return objArticulo;
        }//Fin ingresar

        //Listar articulo
        public Articulo listarArticulo(Articulo objArticulo)
        {
            //BaseDatos objDB = new BaseDatos();
            //objServTecnico = objDB.ingresar(objServTecnico);

            return objArticulo;
        }//Fin listar

        //Modificar articulo
        public Articulo modificarArticulo(Articulo objArticulo)
        {
            //BaseDatos objDB = new BaseDatos();
            //objServTecnico = objDB.ingresar(objServTecnico);

            return objArticulo;
        }//Fin modificar

        //Eliminar articulo
        public Articulo eliminarArticulo(Articulo objArticulo)
        {
            //BaseDatos objDB = new BaseDatos();
            //objServTecnico = objDB.ingresar(objServTecnico);

            return objArticulo;
        }//Fin eliminar
        #endregion
    }
}
