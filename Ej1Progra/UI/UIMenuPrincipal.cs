using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1Progra.UI
{
    class UIMenuPrincipal
    {
        public string showMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-Menu Principal-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Console.WriteLine("1. Registrar Cuenta");
            Console.WriteLine("2. Modificar los datos de un cliente");
            Console.WriteLine("3. Consultar por un cliente");
            Console.WriteLine("4. Deshabilitar temporalmente la clave del administrador");
            Console.WriteLine("5. Liberar una cuenta bloqueada");
            Console.WriteLine("6. Realizar transacciones");
            Console.WriteLine("7. Salir");
            Console.WriteLine("");
            Console.Write("Inserte tu opcion: ");

            return Console.ReadLine();            
        }

        public List<string> showRegCuent()
        {
            List<string> Values = new List<string>();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("-* Inserte los datos del Cliente y Cuenta*-");
            Console.WriteLine("");
            Console.Write("Cliente Id: ");
            Values.Add(Console.ReadLine());
            Console.Write("Cliente Nombre: ");
            Values.Add(Console.ReadLine());
            Console.Write("Cliente Apellido: ");
            Values.Add(Console.ReadLine());
            Console.Write("Cliente Telefono: ");
            Values.Add(Console.ReadLine());
            Console.Write("Cliente Credito: ");
            Values.Add(Console.ReadLine());

            return Values;
        }

        public List<string> showMenuOptionTwo()
        {
            List<string> options = new List<string>();

            Console.WriteLine("");
            Console.WriteLine("-*-* Modificar Datos Clientes *-*-");
            Console.WriteLine("1. Nombre");
            Console.WriteLine("2. Apellido");
            Console.WriteLine("3. Telefono");
            Console.WriteLine("4. Contrasenna");
            Console.WriteLine("");
            Console.Write("Ingrese el ID del cliente que quiere editar: ");
            options.Add(Console.ReadLine());
            Console.Write("Ingrese la opcion del dato que quiere editar: ");
            options.Add(Console.ReadLine());
            Console.Write("Ingrese el nuevo dato: ");
            options.Add(Console.ReadLine());

            return options;
        }
    }
}
