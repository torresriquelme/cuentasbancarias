using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        enum Opcion { Deposito = 1, Retiro, Transferencia, Consulta, Salida};

        static void Main(string[] args)
        {
            //Esta primera parte crea los datos que estarían en la base de datos.
            // Definición de Cliente y cuenta
            Cliente cliente = new Cliente("John Doe");

            // Listado de Cuentas Ahorro
            BDCuentasAhorro listadoCuentasAhorro = new BDCuentasAhorro();
            listadoCuentasAhorro.NuevaCuenta("Jorge Torres", 120000);
            cliente.CrearCuentaAhorro(listadoCuentasAhorro.NuevaCuenta(cliente.Nombre, 500));
            listadoCuentasAhorro.NuevaCuenta("Bill Gates", 75000);
            cliente.CrearCuentaAhorro(listadoCuentasAhorro.NuevaCuenta(cliente.Nombre, 1500));
            listadoCuentasAhorro.NuevaCuenta("Mariano Rajoy", 65000);

            // Listado de Cuentas Corrientes
            BDCuentasCorrientes listadoCuentasCorrientes = new BDCuentasCorrientes();
            listadoCuentasCorrientes.NuevaCuenta("El Chapo Guzman", 250000);
            cliente.CrearCuentaCorriente(listadoCuentasCorrientes.NuevaCuenta(cliente.Nombre, 7800));
            listadoCuentasCorrientes.NuevaCuenta("Thomas Edison", 33400);

          
            
            // Funciones del Cajero Automático
            //Se simula la transaccion del cliente John Doe quien posee tres cuentas con el banco.
            //Validación y consulta base de datos.
            int seleccion = 0;
            CuentaAhorro[] cuentasAhorroCliente = listadoCuentasAhorro.ListadoPorCliente(cliente.ListadoCuentasAhorro());
            CuentaCorriente[] cuentasCorrientesCliente = listadoCuentasCorrientes.ListadoPorCliente(cliente.ListadoCuentasCorriente());
            while ( seleccion != (int)Opcion.Salida)
            {
                ImprimeCabecera(cliente.Nombre, "", "");
                seleccion = imprimeSeleccion();
                switch (seleccion)
                {
                    case (int)Opcion.Deposito:
                        Console.Clear();
                        Deposito(cliente, cuentasAhorroCliente, cuentasCorrientesCliente);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case (int)Opcion.Retiro:
                        Console.Clear();
                        Retiro(cliente, cuentasAhorroCliente, cuentasCorrientesCliente);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case (int)Opcion.Consulta:
                        Console.Clear();
                        Consulta(cliente, cuentasAhorroCliente, cuentasCorrientesCliente);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case (int)Opcion.Transferencia:
                        Console.Clear();
                        Transferencia(cliente, cuentasAhorroCliente, cuentasCorrientesCliente);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                 
                    default:
                        break;
                }
            }
        }
        
        
        public static void ImprimeCabecera(string nombre, string transaccion, string mensaje)
        {
            Console.WriteLine("Banco Nacional de Rupunia");
            Console.WriteLine("Nombre del cliente: " + nombre);
            Console.WriteLine("\n=======================================\\n");
            if (transaccion != "")
            {
                Console.WriteLine("Tipo de Transacción: " + transaccion); 
            }
            if(mensaje != "")
            {
                Console.WriteLine("***** Atención: " + mensaje + " ***\n");
            }
        }

        public static int imprimeSeleccion()
        {
            Console.Write("Seleccione una opción:");
            Console.WriteLine("Seleccione su operación");
            Console.WriteLine("1.- Deposito\n2.- Retiro\n3.- Transferencia\n4.- Consulta\n5.- Salir");
            return Convert.ToInt16(Console.ReadLine());
        }

        public static void Deposito(Cliente cliente, CuentaAhorro[] cuentasAhorro, CuentaCorriente[] cuentasCorrientes)
        {
            ImprimeCabecera(cliente.Nombre, "Deposito", "");
            Console.WriteLine("Seleccione la cuenta para efectuar el depósito\n");
            int opt = 0;
            foreach (CuentaAhorro cuenta in cuentasAhorro)
            {
                Console.WriteLine(opt + ".- Cuenta Ahorros Id: " + cuenta.Id + " , Saldo: " + cuenta.Saldo);
                opt++;
            }
            foreach (CuentaCorriente cuenta in cuentasCorrientes)
            {
                Console.WriteLine(opt + ".- Cuenta Corriente Id: " + cuenta.Id + " , Saldo: " + cuenta.Saldo);
                opt++;
            }

            int seleccion = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Indique el Monto");
            double monto = Convert.ToDouble(Console.ReadLine());
            if(seleccion < cuentasAhorro.Length)
            {
                cuentasAhorro[seleccion].Deposito(monto);
            }
            else
            {
                cuentasCorrientes[seleccion - cuentasAhorro.Length].Deposito(monto);
            }
            Console.WriteLine("\nTransaccion realizada con exito\n");
        }

        public static void Retiro(Cliente cliente, CuentaAhorro[] cuentasAhorro, CuentaCorriente[] cuentasCorrientes)
        {
            ImprimeCabecera(cliente.Nombre, "Retiro", "");
            Console.WriteLine("Seleccione la cuenta para efectuar el retiro\n");
            int opt = 0;
            foreach (CuentaAhorro cuenta in cuentasAhorro)
            {
                Console.WriteLine(opt + ".- Cuenta Ahorros Id: " + cuenta.Id + " , Saldo: " + cuenta.Saldo);
                opt++;
            }
            foreach (CuentaCorriente cuenta in cuentasCorrientes)
            {
                Console.WriteLine(opt + ".- Cuenta Corriente Id: " + cuenta.Id + " , Saldo: " + cuenta.Saldo);
                opt++;
            }

            int seleccion = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Indique el Monto");
            double monto = Convert.ToDouble(Console.ReadLine());
            if (seleccion < cuentasAhorro.Length)
            {
                cuentasAhorro[seleccion].Retiro(monto);
            }
            else
            {
                cuentasCorrientes[seleccion - cuentasAhorro.Length].Retiro(monto);
            }
            Console.WriteLine("\nTransaccion realizada con exito\n");
        }

        public static void Consulta(Cliente cliente, CuentaAhorro[] cuentasAhorro, CuentaCorriente[] cuentasCorrientes)
        {
            ImprimeCabecera(cliente.Nombre, "Consulta", "");
            Console.WriteLine("Listado de cuentas del cliente\n");
            int opt = 0;
            foreach (CuentaAhorro cuenta in cuentasAhorro)
            {
                Console.WriteLine(opt + ".- Cuenta Ahorros Id: " + cuenta.Id + " , Saldo: " + cuenta.Saldo);
                opt++;
            }
            foreach (CuentaCorriente cuenta in cuentasCorrientes)
            {
                Console.WriteLine(opt + ".- Cuenta Corriente Id: " + cuenta.Id + " , Saldo: " + cuenta.Saldo);
                opt++;
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar");
        }

        public static void Transferencia(Cliente cliente, CuentaAhorro[] cuentasAhorro, CuentaCorriente[] cuentasCorrientes)
        {
            ImprimeCabecera(cliente.Nombre, "Transferencia", "");
            Console.WriteLine("Listado de cuentas\n");
            int opt = 0;
            foreach (CuentaAhorro cuenta in cuentasAhorro)
            {
                Console.WriteLine(opt + ".- Cuenta Ahorros Id: " + cuenta.Id + " , Saldo: " + cuenta.Saldo);
                opt++;
            }
            foreach (CuentaCorriente cuenta in cuentasCorrientes)
            {
                Console.WriteLine(opt + ".- Cuenta Corriente Id: " + cuenta.Id + " , Saldo: " + cuenta.Saldo);
                opt++;
            }

            Console.WriteLine("\nSeleccione cuenta a Debitar");
            int selDeb = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\nSeleccione cuenta a Acreditar");
            int selCred = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("\nIndique el Monto");
            double monto = Convert.ToDouble(Console.ReadLine());

            if (selDeb < cuentasAhorro.Length)
            {
                cuentasAhorro[selDeb].Retiro(monto);
            }
            else
            {
                cuentasCorrientes[selDeb - cuentasAhorro.Length].Retiro(monto);
            }

            if (selCred < cuentasAhorro.Length)
            {
                cuentasAhorro[selCred].Deposito(monto);
            }
            else
            {
                cuentasCorrientes[selCred - cuentasAhorro.Length].Deposito(monto);
            }

            Console.WriteLine("\nTransaccion realizada con exito\n");
        }
    }
}
