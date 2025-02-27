using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<double> ingresos = new List<double>();
        List<double> gastos = new List<double>();
        int opcion;

        do
        {
            Console.WriteLine("1. Registrar Ingreso");
            Console.WriteLine("2. Registrar Gasto");
            Console.WriteLine("3. Ver Balance");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    RegistrarIngreso(ingresos);
                    break;
                case 2:
                    RegistrarGasto(gastos);
                    break;
                case 3:
                    VerBalance(ingresos, gastos);
                    break;
                case 4:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }

        } while (opcion != 4);
    }

    static void RegistrarIngreso(List<double> ingresos)
    {
        Console.Write("Ingrese la cantidad del ingreso: ");
        double ingreso = double.Parse(Console.ReadLine());
        ingresos.Add(ingreso);
        Console.WriteLine("Ingreso registrado correctamente.\n");
    }

    static void RegistrarGasto(List<double> gastos)
    {
        Console.Write("Ingrese la cantidad del gasto: ");
        double gasto = double.Parse(Console.ReadLine());
        gastos.Add(gasto);
        Console.WriteLine("Gasto registrado correctamente.\n");
    }

    static void VerBalance(List<double> ingresos, List<double> gastos)
    {
        double totalIngresos = 0;
        double totalGastos = 0;

        foreach (double ingreso in ingresos)
        {
            totalIngresos += ingreso;
        }

        foreach (double gasto in gastos)
        {
            totalGastos += gasto;
        }

        double balance = totalIngresos - totalGastos;

        Console.WriteLine($"Total de ingresos: {totalIngresos:C}");
        Console.WriteLine($"Total de gastos: {totalGastos:C}");
        Console.WriteLine($"Balance: {balance:C}\n");
    }
}