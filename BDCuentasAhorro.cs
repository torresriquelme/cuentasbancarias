using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class BDCuentasAhorro
    {
        List<CuentaAhorro> ListadoCuentasAhorro = new List<CuentaAhorro>();

        public int NuevaCuenta(string nombre, double saldo)
        {
            var id = 0;
            if (ListadoCuentasAhorro.Count != 0)
            {
                id = this.ListadoCuentasAhorro.Last<CuentaAhorro>().Id;
            }
            ListadoCuentasAhorro.Add(new CuentaAhorro() { Nombre = nombre, Saldo = saldo, Id = id + 1});
            return id + 1;
        }

        public double ConsultaSaldo(int cuenta)
        {
            for(int i = 0; i < ListadoCuentasAhorro.Count; i++)
            {
                if(ListadoCuentasAhorro[i].Id == cuenta)
                {
                    return ListadoCuentasAhorro[i].Saldo;
                }
            }
            return -1;
        }

        public int Deposito(int cuenta, double monto)
        {
            for (int i = 0; i < ListadoCuentasAhorro.Count; i++)
            {
                if (ListadoCuentasAhorro[i].Id == cuenta)
                {
                    ListadoCuentasAhorro[i].Saldo += monto;
                    return ListadoCuentasAhorro[i].Id;
                }
            }
            return -1;
        }

        public int Retiro(int cuenta, double monto)
        {
            for (int i = 0; i < ListadoCuentasAhorro.Count; i++)
            {
                if (ListadoCuentasAhorro[i].Id == cuenta)
                {
                    ListadoCuentasAhorro[i].Saldo -= monto;
                    return ListadoCuentasAhorro[i].Id;
                }
            }
            return -1;
        }

        public CuentaAhorro[] ListadoCompleto()
        {
            return this.ListadoCuentasAhorro.ToArray();
        }

        public CuentaAhorro[] ListadoPorCliente(int[] cuentas)
        {
            List<CuentaAhorro> listado = new List<CuentaAhorro>();
            foreach (int id in cuentas)
            {
                listado.Add(this.ListadoCuentasAhorro[id-1]);

            }
            return listado.ToArray();
        }
    }
}
