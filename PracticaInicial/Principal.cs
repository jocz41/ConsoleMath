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
    class Principal
    {
        #region Deshabilitar Botón de Cerrar
        //Fragmento de código que deshabilita el botón de cerrar la ventana
        private const int _MF_BYCOMMAND = 0x00000000;   //Número que indica un uso por defecto
        public const int SC_CLOSE = 0xF060;            //Número que identifica al botón de cerrar ventana

        //Necesitamos importar las user32.dll para poder manejar la ventana de consola
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [System.Runtime.InteropServices.DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        #endregion

        static void Main(string[] args)
        {
            /*DeleteMenu elimina la funcionalidad del ítem pasado como segundo parámetro
             * según dicte el tercer parámetro de la ventana indicada por el primer parámetro */

            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, _MF_BYCOMMAND);
            int opcion = 0;
            
            //Bucle que muestra el menú hasta que el usuario desee salir (3)     
            do
            {
                menu();
                if(comprobarNum(Console.ReadLine(), ref opcion))
                    llamar(opcion);
            }
            while (opcion != 3);
        }
        
        #region Comprobación de Inputs
        //Método para comprobar que la entrada sea un número entero
        private static bool comprobarNum(string s, ref int n)
        {
            bool esNum =  int.TryParse(s, out n);

            if (s.Length == 0)  //Comprueba que no esté vacío
            {
                impError("\nERROR. No ha introducido ningún valor.\n");
            }
            else if (!esNum)    //Comprueba que sea un valor numérico
            {
                impError("\nERROR. Valor no entero numérico.\n");
            }
            else if (s.Length > 8)  //Limita la longitud
            {
                impError("\nERROR. Número demasiado extenso.\n");
                esNum = false;
            }

            return esNum;
        }

        //Método para comprobar que la entrada sea un double
        private static bool comprobarNum(string s, ref double n)
        {
            //Sustitución del punto por una coma en caso de decimal
            s = s.Replace('.', ',');

            bool esNum = double.TryParse(s, out n);

            if (s.Length == 0)  //Comprueba que no esté vacío
            {
                impError("\nERROR. No ha introducido ningún valor.\n");
            }
            else if (!esNum)    //Comprueba que sea un valor numérico
            {
                impError("\nERROR. Valor no numérico.\n");
            }
            else if (s.Length > 15)  //Limita la longitud
            {
                impError("\nERROR. Número demasiado extenso.\n");
                esNum = false;
            }

            return esNum;
        }
        #endregion

        #region Métodos para recoger datos
        //Método para recoger datos double
        private static void intDatos(string s, ref double n)
        {
            do
            {
                Console.Write("\nIntroduzca ");
                Principal.impVerde(s);
                Console.Write(": ");
            }
            while (!comprobarNum(Console.ReadLine(), ref n));
        }

        //Método para recoger datos int
        private static void intDatos(string s, ref int n)
        {
            do
            {
                Console.Write("\nIntroduzca ");
                Principal.impVerde(s);
                Console.Write(": ");
            }
            while (!comprobarNum(Console.ReadLine(), ref n));
        }
        #endregion

        #region Imprimir especiales
        //Método para imprimir errores en rojo
        public static void impError(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(s);
            Console.ResetColor();
            Console.Write("\nPulse cualquier tecla para continuar.");
            Console.ReadKey();
            Console.WriteLine("\n");
        }

        //Imprime los títulos en azul
        public static void impTitulo(string s)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(s);
            Console.ResetColor();
        }

        //Imprime en verde
        public static void impVerde(string s)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(s);
            Console.ResetColor();
        }
        #endregion

        #region Menú
        //Método que representa el menú
        private static void menu()
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("|    Seleccione una opción:         |");
            Console.WriteLine("| 1. Resolver ecuación de 2º Grado  |");
            Console.WriteLine("| 2. Mostrar tabla de Multiplicar   |");
            Console.WriteLine("| 3. Salir                          |");
            Console.WriteLine("└───────────────────────────────────┘\n");
        }

        //Método que llama _a la opción seleccionada por el usuario
        private static void llamar(int n)
        {
            switch (n)
            {
                case 1:
                    ecuacion();     //Ecuación de Segundo Grado
                    break;
                case 2:
                    tabla();        //Tabla
                    break;
                case 3:
                    Environment.Exit(0);    //Cierra la consola
                    break;
                default:
                    impError("\nOpción no válida.\n");
                    break;
            }
        }
        #endregion

        #region Llamadas a las operaciones
        //Método que recoge los datos necesarios para realizar la ecuación de 2º grado
        private static void ecuacion()
        {
            #region variables
            double a = 0, b = 0, c = 0;
            #endregion

            impTitulo("\nCálculo de una ecuación de 2º Grado\n");

            #region Recogida de datos
            intDatos("a", ref a);
            intDatos("b", ref b);
            intDatos("c", ref c);
            #endregion

            new Ecuacion(a,b,c).calcularEc();
        }

        //Método que recoge los datos para mostrar la tabla de multiplicar
        private static void tabla()
        {
            #region Variables
            double f = 0;
            int n = 0;
            #endregion

            impTitulo("\nTabla de multiplicar\n");

            #region Recogida de Datos
            intDatos("el factor", ref f);

            do
            {
                intDatos("el número de elementos a mostrar", ref n);
            } while (n < 0);
            #endregion

            new Tabla(f, n).mostrarTabla();
        }
        #endregion
    }
}
