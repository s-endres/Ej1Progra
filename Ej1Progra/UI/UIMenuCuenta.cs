using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1Progra.UI
{
    class UIMenuCuenta
    {
        public string showMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Console.WriteLine("1. Retirar monto");
            Console.WriteLine("2. Pagar tarjeta");
            Console.WriteLine("3. Comprar articulo");
            Console.WriteLine("4. Consultar saldos");
            Console.WriteLine("5. Consultar transacciones");
            Console.WriteLine("6. Cambiar pin");
            Console.WriteLine("7. Salir");
            Console.WriteLine("");
            Console.Write("Inserte tu opcion: ");

            return Console.ReadLine();
        }
    }
}
