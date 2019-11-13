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
    class Ecuacion
    {
        #region Atributos
        private double _a, _b, _c;
        private List<Complejo> _r;
        #endregion

        #region Constructor
        public Ecuacion(double a, double b, double c)
        {
            this._a = a;
            this._b = b;
            this._c = c;
        }
        #endregion

        public void calcularEc()
        {
            //Comprobamos si a es 0, ya que esto nos dará una división entre 0, lo cual es infinito
            if(_a == 0)
            {
                Console.Write("\nEl resultado es ");
                Principal.impVerde("infinito.\n");
            }
            else
            {
                //Llamada al método resultado
                resultado();

                //Mostramos los resultados en consola
                Console.Write("\nResultados: ");
                Principal.impVerde("x1 = ");
                _r[0].mostrar();
                Principal.impVerde("     x2 = ");
                _r[1].mostrar();
            }

            Console.Write("\n\nPulse cualquier tecla para continuar.");
            Console.ReadKey();
            Console.Clear();
        }

        //Método que calcula y almacena los resultados de la ecuación
        private List<Complejo> resultado()
        {
            #region Variables
            _r = new List<Complejo>();
            double n, raiz, img = 0, real;
            bool complejo = false;
            #endregion
            
            //Calculamos el radicando
            n = Math.Pow(_b, 2) - 4 * _a * _c;

            //Si el radicando es negativo le cambiamos el signo para calcularlo como complejo
            if (n < 0)
            {
                complejo = true;
                n = -n;
            }

            //Calculamos la raiz
            raiz = Math.Sqrt(n);

            //Si hemos obtenido un radicando negativo
            if(complejo)
            {
                img = raiz / (2 * _a);
                real = -_b / (2 * _a);

                //Cálculo considerando la suma
                _r.Add(new Complejo(real, img));

                //Cálculo considerando la resta
                _r.Add(new Complejo(real, -img));
            }
            //Si hemos obtenido un radicando positivo
            else
            {
                //Cálculo considerando la suma
                real = (-_b + raiz) / (2 * _a);
                _r.Add(new Complejo(real, 0));

                //Cálculo considerando la resta
                real = (-_b - raiz) / (2 * _a);
                _r.Add(new Complejo(real, 0));
            }
            
            return _r;
        }
    }
}
