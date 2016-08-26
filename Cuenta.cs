using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Cuenta
    {
        public double Saldo { get; set; }
        public string Moneda { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }

        public void Retiro(double monto)
        {
            this.Saldo -= monto;
        }

        public void Deposito(double monto)
        {
            this.Saldo += monto;
        }
    }
}
