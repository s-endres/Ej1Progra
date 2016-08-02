using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1Progra.Logic
{
    class Cliente
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string Contrasenna { get; set; }
        public List<Cuenta> Cuentas { get; set; }

        private Cliente()
        {
        }
        public Cliente(int pPersonaId, string pNombre, string pApellido, int pTelefono)
        {
            PersonaId = pPersonaId;
            Nombre = pNombre;
            Apellido = pApellido;
            Telefono = pTelefono;
            Cuentas = new List<Cuenta>();
            setMyPassword();
        }
        public void addCuenta(Cuenta pCuenta)
        {
            Cuentas.Add(pCuenta);
        }
        private void setMyPassword()
        {
            string NameInitial = Nombre.Substring(0, 1);
            string ApellidoInitial = Apellido.Substring(0, 1);
            string IdFirstThree = PersonaId.ToString().Substring(0, 3);

            Contrasenna = NameInitial + ApellidoInitial + IdFirstThree;
        }

        public void showMyData()
        {
            Console.WriteLine("****");
            Console.WriteLine("Cliente: ");
            Console.WriteLine("-Id: "+this.PersonaId);
            Console.WriteLine("-Nombre: "+this.Nombre);
            Console.WriteLine("-Apellido: " + this.Apellido);
            Console.WriteLine("-Telefono: " + this.Telefono);
            Console.WriteLine("-Contrasenna: " + this.Contrasenna + "<---");

            Console.WriteLine("**Cuentas: ");
            foreach (var cuenta in this.Cuentas)
            {
                Console.WriteLine("-Numero: "+cuenta.CuentaId);
                Console.WriteLine("-Credito: " + cuenta.Credito);
                Console.WriteLine("*");
            }
            Console.WriteLine("****");

        }
    }
}
