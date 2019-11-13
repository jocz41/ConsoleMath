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
    class Tabla
    {
        #region Atributos
        private int _numero;     //Número de elementos _a mostrar
        private double _factor;
        #endregion

        #region Constructor
        public Tabla(double f, int n)
        {
            _factor = f;
            _numero = n;
        }
        #endregion

        public void mostrarTabla()
        {
            Console.WriteLine();

            /*Las líneas de código que mencionan al cursor de la consola 
            se deben _a una mejor representación de la tabla de multiplicar en 3 columnas*/
            
            int hztl = 0, top = Console.CursorTop + 1;

            for(int i = 1; i <= _numero; i++)
            {
                Console.SetCursorPosition(hztl, top);    //Situamos el cursor en la esquina superior izqda. de la siguiente línea
                Principal.impVerde("" + _factor + " x " + i + " = ");
                Console.ResetColor();

                //Redondeamos el resultado _a 2 cifras decimales
                Console.Write(Math.Round(_factor*i,2)+"\t\t");

                //Movemos el cursor hacia la derecha     
                hztl += 40;                                        

                if (i % 2 == 0)
                {
                    Console.WriteLine();        //Saltamos _a la siguiente línea
                    top++;
                    hztl = 0;
                }
            }

            Console.Write("\n\nPulse cualquier tecla para continuar.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
