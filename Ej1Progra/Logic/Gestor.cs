using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1Progra.Logic
{
    class Gestor
    {
        List<Cliente> Clientes = new List<Cliente>();
        Cliente Admin = new Cliente(999, "Admin", "AdminA", 0);
        Cliente SessionCliente;
        public bool registrarCuenta(int pId, string pNombre, string pApellido, int pTelefono, double? pCredito)
        {
            bool result = false;
            bool foundClient = false;
            foreach (var cliente in Clientes)
            {
                if(cliente.PersonaId == pId)
                {
                    foundClient = true;

                    int ClienteCuentaCount = cliente.Cuentas.Count()+1;
                    cliente.Cuentas.Add(new Logic.Cuenta("cta-"+ ClienteCuentaCount, pCredito));

                    cliente.showMyData();
                    result = true;
                    break;
                }
            }

            if (!foundClient)
            {
                Cliente objCliente = new Cliente(pId, pNombre,pApellido,pTelefono);
                Cuenta objCuenta = new Logic.Cuenta("cta-1", pCredito);
                objCliente.addCuenta(objCuenta);

                Clientes.Add(objCliente);
                objCliente.showMyData();
                result = true;
            }
            return result;
        }

        public bool modifyClient(List<string> pOptions)
        {
            bool result = false;

            foreach (var cliente in Clientes)
            {
                if (cliente.PersonaId == int.Parse(pOptions[0]))
                {
                    switch (pOptions[1])
                    {
                        case "1":
                            cliente.Nombre = pOptions[2];
                            break;
                        case "2":
                            cliente.Apellido = pOptions[2];
                            break;
                        case "3":
                            cliente.Telefono = int.Parse(pOptions[2]);
                            break;
                        case "4":
                            cliente.Contrasenna = pOptions[2];
                            break;
                    }

                    cliente.showMyData();
                    result = true;
                    break;
                }
            }

            return result;
        }

        public bool validateAdmin(string pContrasenna)
        {
            bool result = false;

            if (pContrasenna == Admin.Contrasenna)
            {
                result = true;
            }

            return result;
        }


        public bool showClientInfo(string pClientId)
        {
            foreach (var cliente in Clientes)
            {
                if (cliente.PersonaId == int.Parse(pClientId))
                {
                    cliente.showMyData();
                    return true;
                }
            }
            return false;
        }

        public bool unblockClientAccount(string pClientId, string pCuentaId)
        {
            foreach (var cliente in Clientes)
            {
                if (cliente.PersonaId == int.Parse(pClientId))
                {
                    foreach (var cuenta in cliente.Cuentas)
                    {
                        if (cuenta.CuentaId == pCuentaId)
                        {
                            cuenta.Bloqueada = false;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool validateClientLogIn(string pClientId, string pCPassword)
        {
            foreach (var cliente in Clientes)
            {
                if (cliente.PersonaId == int.Parse(pClientId) && cliente.Contrasenna == pCPassword)
                {
                    SessionCliente = cliente;
                    return true;
                }
            }
            return false;
        }

        public string retireAmountFromAccount(string pAccountId, double pAmount)
        {
            string msg = "";
            foreach (var cuenta in SessionCliente.Cuentas)
            {
                if (cuenta.CuentaId == pAccountId)
                {
                    if (cuenta.Saldo < pAmount)
                    {
                        msg = "Su monto es mayor al saldo disponible";
                    }
                    else
                    {
                        cuenta.Saldo = cuenta.Saldo - pAmount;
                        double comisionUnoPCT = cuenta.Credito * 1 / 100;
                        cuenta.Saldo = cuenta.Saldo - comisionUnoPCT;

                        Transaccion objTransaccion = new Transaccion(DateTime.Now,"Retiro",pAmount);
                        cuenta.addTransaccion(objTransaccion);

                        var retiroCount = cuenta.Transacciones.Count(t => t.Tipo == "Retiro");
                        double saldoAdeudado = cuenta.Credito - cuenta.Saldo;

                        msg = DateTime.Now.ToString()+" Retiro-"+retiroCount+" Monto:"+pAmount+" Tiene un saldo adeudado de:"+ saldoAdeudado;
                    }
                }
            }
            return msg; 
        }




    }
}
