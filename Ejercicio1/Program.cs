using System;

namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingresa un Numero (MAX 3 Cifras): ");
            var num = Convert.ToInt32(Console.ReadLine());

            var resultado = num / 100;

            Console.WriteLine($"Cantidad de Centenas: " + resultado.ToString());
            Console.WriteLine($"Cantidad de Centenas: { num / 100 }");
            Console.WriteLine("Cantidad de Centenas: {0} {1}", 
                resultado.ToString(), resultado.ToString());
            
            
            Console.WriteLine($"Cantidad de Decenas: { (num % 100) / 10 }");
            Console.WriteLine($"Cantidad de Unidades: { (num % 10) }");
        }
    }
}
