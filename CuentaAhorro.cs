using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class CuentaAhorro: Cuenta
    {
        public double TasaInteres { get; set; }
        //public string Nombre { get; set; }
        //public int Id { get; set; }

        public void Intereses()
        {
            this.Saldo += TasaInteres * 0.01 * this.Saldo / 12;
        }
 
    }
}
