/*
* PRÁCTICA.............: Práctica Inicial.
* NOMBRE y APELLIDOS...: Sara Blanco Muñoz
* CURSO y GRUPO........: 2º DAM
* TÍTULO de la PRÁCTICA: Uso del IDE V.Studio
* FECHA de ENTREGA.....: 16 de Octubre de 2017
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticaInicial
{
    //Se puede tener sin constructor

    class Complejo
    {
        #region Atributos
        public double _real
        {
            get { return _real; }
            set { _real = value; }
        }

        public double _img
        {
            get { return _img; }
            set { _img = value; }
        }
        #endregion

        #region Constructor
        public Complejo(double x, double y)
        {
            _real = Math.Round(x, 2);
            _img = Math.Round(y,2);
        }
        #endregion

        public void mostrar()
        {
            Console.Write(_real+" + ("+_img+"i)");
        }
    }
}
