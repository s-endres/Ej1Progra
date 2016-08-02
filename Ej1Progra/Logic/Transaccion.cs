using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1Progra.Logic
{
    class Transaccion
    {
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public double Monto { get; set; }

        private Transaccion() {}

        public Transaccion(DateTime pFecha, string pTipo, double pMonto)
        {
            Fecha = pFecha;
            Tipo = pTipo;
            Monto = pMonto;
        }
    }
}
