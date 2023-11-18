
using System;

class Program
{
    static void Main()
    {
        try
        {

            Console.Write("Ingresa el primer valor: ");
            double VALOR1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingresa el segundo valor: ");
            double VAlOR2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Seleccione la operacion que desea realizar:");
            Console.WriteLine("1. Suma");
            Console.WriteLine("2. Resta");
            Console.WriteLine("3. Multiplicación");
            Console.WriteLine("4. División");

            int Option = Convert.ToInt32(Console.ReadLine());

            double Resultado = 0;

            switch (Option)
            {
                case 1:
                    Resultado = Suma(VALOR1, VAlOR2);
                    break;
                case 2:
                    Resultado = Resta(VALOR1, VAlOR2);
                    break;
                case 3:
                    Resultado = Multiplicación(VALOR1, VAlOR2);
                    break;
                case 4:
                    Resultado = Dividisión(VALOR1, VAlOR2);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    return;
            }

            Console.WriteLine("Resultado: " + Resultado);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Ingrese valores numéricos válidos.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: No se puede dividir entre cero.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static int[] operaciones = { 1, 2, 3, 4 };

    static double Suma(double A, double B)
    {
        return A + B;
    }

    static double Resta(double A, double b)
    {
        return A - b;
    }

    static double Multiplicación(double A, double B)
    {
        return A * B;
    }

    static double Dividisión(double A, double B)
    {
        if (B == 0)
        {
            throw new DivideByZeroException("No se puede dividir entre cero.");
        }
        return A / B;
    }
}


