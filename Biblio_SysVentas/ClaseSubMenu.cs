using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio_SysVentas
{
    public class ClaseSubMenu
    {
        public static void subMenu(int valor, string[] arreglo)
        {
            //Indico la posición del submenu
            int izquierda = 0;
            if (valor == 0)
            {
                izquierda = 1;
            }
            else if (valor == 1)
            {
                izquierda = 16;
            }
            else if (valor == 2)
            {
                izquierda = 31;
            }
            else if (valor == 3)
            {
                izquierda = 46;
            }
            else if (valor == 4)
            {
                izquierda = 61;
            }

            for (int i = 0; i < arreglo.Length; i++)
            {
                Console.SetCursorPosition(izquierda, 5 + i);
                Console.WriteLine(" " + arreglo[i]);
            }
        }

        public static int SubInterfaz(int valor, string[] arreglo)
        {

        }
    }
}

