using Ej1Progra.BD;
using Ej1Progra.Logic;
using Ej1Progra.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Ej1Progra
{
    class Program
    {

        static UIMenuPrincipal g_objUIMenuP = new UIMenuPrincipal();
        static UIMenuCuenta g_objMenuC = new UIMenuCuenta();
        static Gestor g_objGestor = new Gestor();
        static bool g_adminLoginActive = true;
        
        static void Main(string[] args)
        {
            DataInsertion objDataInsertion = new DataInsertion();
            objDataInsertion.insertMyData(g_objGestor);
            showBienvenido();

            string option = "";
            do
            {
                option = g_objUIMenuP.showMenu();
                switch (option)
                {
                    case "1":
                        adminLogin(); //We ask for the Admin Password ulti is right
                        doOptionOne();
                        break;
                    case "2":
                        adminLogin(); //We ask for the Admin Password ulti is right
                        var result = g_objUIMenuP.showMenuOptionTwo();
                        doOptionTwo(result);
                        break;
                    case "3":
                        adminLogin(); //We ask for the Admin Password ulti is right
                        doOptionThree();
                        break;
                    case "4":
                        adminLogin(); //We ask for the Admin Password ulti is right
                        g_adminLoginActive = false;
                        break;
                    case "5":
                        adminLogin(); //We ask for the Admin Password ulti is right
                        doOptionFive();
                        break;
                    case "6":
                        doOptionSix();
                        break;
                    case "7":
                        Console.WriteLine("Saliendo del sistema..");
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }

            } while (option != "7");
        }

        public static void showBienvenido()
        {
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("d8888b .d888888b d88888b d8b   db db    db d88888b d8b   db d888888b d8888b.  .d88b.  ");
            Console.WriteLine("88  `8D   `88'   88'     888o  88 88    88 88'     888o  88   `88'   88  `8D .8P Y8.  ");
            Console.WriteLine("88oooY'    88    88ooooo 88V8o 88 Y8    8P 88ooooo 88V8o 88    88    88   88 88    88 ");
            Console.WriteLine("88~~~b.    88    88~~~~~ 88 V8o88 `8b d8'  88~~~~~ 88 V8o88    88    88   88 88    88 ");
            Console.WriteLine("88   8D   .88.   88.     88  V888  `8bd8'  88.     88  V888   .88.   88  .8D `8b  d8' ");
            Console.WriteLine("Y8888P' Y888888P Y88888P VP   V8P    YP    Y88888P VP   V8P Y888888P Y8888D'  `Y88P'  ");
            Console.WriteLine("**************************************************************************************");
        }

        public static void adminLogin()
        {
            if (g_adminLoginActive) { 
                bool result = false;
                do {
                    Console.Write("Insert admin password: ");
                    var AdminPassword = Console.ReadLine();
                    result = g_objGestor.validateAdmin(AdminPassword);
                } while (result == false);
            }
        }
        public static void doOptionOne()
        {
            List<string> Values = g_objUIMenuP.showRegCuent();
            double? credit = 0;

            if (Values[4].Trim() == "")
                credit = null;
            else
                credit = double.Parse(Values[4]);

            g_objGestor.registrarCuenta(int.Parse(Values[0]), Values[1], Values[2], int.Parse(Values[3]), credit);
        }

        public static void doOptionTwo(List<string> pOption)
        {
            g_objGestor.modifyClient(pOption);
        }

        public static void doOptionThree()
        {
            bool result = false;
            var clientId = "-1";
            do {
                Console.Write("Ingrese el ID del cliente: ");
                clientId = Console.ReadLine();
                result = g_objGestor.showClientInfo(clientId);
                if (!result)
                    Console.WriteLine("-ID incorrecto");
            } while (result==false && clientId!="-1");
        }

        public static void doOptionFive()
        {
            bool result = false;
            var clientId = "-1";
            var cuentaId = "-1";
            do
            {
                Console.Write("(-1 para salir)");
                Console.Write("Ingrese el ID del cliente: ");
                clientId = Console.ReadLine();
                Console.Write("Ingrese el ID de la cuenta: ");
                cuentaId = Console.ReadLine();

                result = g_objGestor.unblockClientAccount(clientId, cuentaId);
                if (!result)
                    Console.WriteLine("-Cliente ID o Cuenta ID incorrecto");
                else
                    Console.WriteLine("***Cuenta Liberada***");

            } while (result == false && clientId != "-1");
        }

        public static void doOptionSix()
        {
            bool result = clientLogIn();
            if (result) {
                string option = "";
                do
                {
                    option = g_objMenuC.showMenu();

                    string msg = "";
                    string accountId = "";
                    switch (option)
                    {
                        case "1":
                            Console.Write("Ingrese el ID de la cuenta: ");
                            accountId = Console.ReadLine();
                            Console.Write("Ingrese el monto a retirar: ");
                            var amountToRetire = Console.ReadLine();
                            msg = g_objGestor.retireAmountFromAccount(accountId, double.Parse(amountToRetire));

                            if (msg == "")
                                msg = "No se encontro la cuenta";
                            Console.WriteLine();
                            Console.WriteLine(msg);

                            break;
                        case "2":
                            Console.Write("Ingrese el ID de la cuenta: ");
                            accountId = Console.ReadLine();
                            Console.Write("Ingrese el monto a pagar: ");
                            var amountToPay = Console.ReadLine();
                            msg = g_objGestor.payAmountFromAccount(accountId, double.Parse(amountToPay));

                            if (msg == "")
                                msg = "No se encontro la cuenta";
                            Console.WriteLine();
                            Console.WriteLine(msg);
                            break;
                        case "3":
                            Console.Write("Ingrese el ID de la cuenta: ");
                            accountId = Console.ReadLine();
                            Console.Write("Ingrese el monto de la compra: ");
                            var amountPurchase = Console.ReadLine();
                            msg = g_objGestor.purchaseFromAccount(accountId, double.Parse(amountPurchase));

                            if (msg == "")
                                msg = "No se encontro la cuenta";
                            Console.WriteLine();
                            Console.WriteLine(msg);

                            break;
                        case "4":
                            Console.Write("Ingrese el ID de la cuenta: ");
                            accountId = Console.ReadLine();
                            msg = g_objGestor.consultarSaldoeFromAccount(accountId);

                            if (msg == "")
                                msg = "No se encontro la cuenta";
                            Console.WriteLine();
                            Console.WriteLine(msg);
                            break;
                        case "5":
                            Console.Write("Ingrese el ID de la cuenta: ");
                            accountId = Console.ReadLine();
                            List<string> transaccionesMsg = g_objGestor.consultarTransaccionesFromAccount(accountId);

                            Console.WriteLine();
                            if (transaccionesMsg == null) { 
                                msg = "No se encontro la cuenta";
                                Console.WriteLine(msg);
                            }
                            else if (transaccionesMsg.Count <= 0)
                            {
                                msg = "La cuenta no tiene transacciones";
                                Console.WriteLine(msg);
                            }
                            else
                            {
                                foreach(var msj in transaccionesMsg)
                                {
                                    Console.WriteLine(msj);
                                }
                            }
                            break;
                        case "6":
                            Console.Write("Ingrese la contrasenna vieja: ");
                            var oldPassword = Console.ReadLine();

                            Console.Write("Ingrese la contrasenna nueva: ");
                            var newPassword = Console.ReadLine();

                            Console.Write("Repita la contrasenna nueva: ");
                            var rNewPassword = Console.ReadLine();

                            Console.WriteLine();//for space

                            if (newPassword == rNewPassword)
                            {
                                result = g_objGestor.changePassword(oldPassword, newPassword);
                                if (result)
                                    Console.WriteLine("La contrasenna fue cambiada con exito");
                                else
                                    Console.WriteLine("La contrasenna vieja no es correcta");
                            }
                            else
                            {
                                Console.WriteLine("Las contrasennas nuevas no coinciden");
                            }

                            break;
                        case "7":
                            Console.WriteLine("Saliendo del menu de cuentas..");
                            break;
                        default:
                            Console.WriteLine("Opcion erronea");
                            break;
                    }
                } while (option != "7");
            }
        }

        public static bool clientLogIn()
        {
            bool result = false;
            do
            {
                Console.Write("(Inserte -1 para salir) ");
                Console.Write("Cliente Id: ");
                var amountToRetire = Console.ReadLine();
                
                if (amountToRetire == "-1")
                    return false;

                Console.Write("Cliente Password: ");
                var clientPassword = Console.ReadLine();

                result = g_objGestor.validateClientLogIn(amountToRetire, clientPassword);


            } while (result == false);

            return true;
        }


    }
}
