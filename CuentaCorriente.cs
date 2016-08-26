using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class CuentaCorriente: Cuenta
    {
        //public string Nombre { get; set; }
        //public int Id { get; set; }
        double Comision = 0.5;

        public void CobrarComision()
        {
            this.Saldo -= Comision;
        }

        public void SolicitarChequera()
        {
            CobrarComision();
        }
    }
}
