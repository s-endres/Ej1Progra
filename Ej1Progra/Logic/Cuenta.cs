
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1Progra.Logic
{
    class Cuenta
    {
        public string CuentaId { get; set; }
        public double Credito { get; set; }
        public double Saldo { get; set; }
        public List<Transaccion> Transacciones { get; set; }
        public bool Bloqueada { get; set; }

        private Cuenta()
        {
        }
        public Cuenta(string pCuentaId, double? pCredito)
        {
            CuentaId = pCuentaId;
            Transacciones = new List<Transaccion>();
            Bloqueada = false;

            if (pCredito == null) 
                Credito = 100000;
            else
                Credito = (double)pCredito;

            Saldo = Credito;
        }
        public void addTransaccion(Transaccion pObjTransaccion)
        {
            Transacciones.Add(pObjTransaccion);
        }

    }
}
