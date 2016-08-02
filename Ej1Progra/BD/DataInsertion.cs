using Ej1Progra.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1Progra.BD
{
    class DataInsertion
    {
        public void insertMyData(Gestor pObjGestor)
        {
            pObjGestor.registrarCuenta(123, "asd", "qwe", 321, 10000);
        }
    }
}
