using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Cliente
    {
        public string Nombre { get; set; }
        public List<int> ListaCuentasAhorro { get; set; }
        public List<int> ListaCuentasCorriente { get; set; }

        //ArrayList ListaCuentas = new ArrayList();

        public Cliente (string nombre)
        {
            Nombre = nombre;
            ListaCuentasAhorro = new List<int>();
            ListaCuentasCorriente = new List<int>();
        }

        public void CrearCuentaAhorro(int cuenta)
        {
            ListaCuentasAhorro.Add(cuenta);
        }

        public int[] ListadoCuentasAhorro()
        {
            return this.ListaCuentasAhorro.ToArray();
        }

        public void CrearCuentaCorriente(int cuenta)
        {
            ListaCuentasCorriente.Add(cuenta);
        }

        public int[] ListadoCuentasCorriente()
        {
            return this.ListaCuentasCorriente.ToArray();
        }
    }
}
