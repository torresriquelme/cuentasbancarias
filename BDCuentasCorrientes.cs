using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class BDCuentasCorrientes
    {
        List<CuentaCorriente> ListadoCuentasCorrientes = new List<CuentaCorriente>();

        public int NuevaCuenta(string nombre, double saldo)
        {
            var id = 0;
            if (ListadoCuentasCorrientes.Count != 0)
            {
                id = this.ListadoCuentasCorrientes.Last<CuentaCorriente>().Id;
            }
            ListadoCuentasCorrientes.Add(new CuentaCorriente() { Nombre = nombre, Saldo = saldo, Id = id + 1 });
            return id + 1;
        }

        public double ConsultaSaldo(int cuenta)
        {
            for (int i = 0; i < ListadoCuentasCorrientes.Count; i++)
            {
                if (ListadoCuentasCorrientes[i].Id == cuenta)
                {
                    return ListadoCuentasCorrientes[i].Saldo;
                }
            }
            return -1;
        }

        public int Deposito(int cuenta, double monto)
        {
            for (int i = 0; i < ListadoCuentasCorrientes.Count; i++)
            {
                if (ListadoCuentasCorrientes[i].Id == cuenta)
                {
                    ListadoCuentasCorrientes[i].Saldo += monto;
                    return ListadoCuentasCorrientes[i].Id;
                }
            }
            return -1;
        }

        public int Retiro(int cuenta, double monto)
        {
            for (int i = 0; i < ListadoCuentasCorrientes.Count; i++)
            {
                if (ListadoCuentasCorrientes[i].Id == cuenta)
                {
                    ListadoCuentasCorrientes[i].Saldo -= monto;
                    return ListadoCuentasCorrientes[i].Id;
                }
            }
            return -1;
        }

        public CuentaCorriente[] ListadoCompleto()
        {
            return this.ListadoCuentasCorrientes.ToArray();
        }

        public CuentaCorriente[] ListadoPorCliente(int[] cuentas)
        {
            List<CuentaCorriente> listado = new List<CuentaCorriente>();
            foreach (int id in cuentas)
            {
                listado.Add(this.ListadoCuentasCorrientes[id - 1]);

            }
            return listado.ToArray();
        }
    }
}
