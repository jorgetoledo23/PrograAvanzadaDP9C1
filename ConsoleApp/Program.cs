using System;

namespace ConsoleApp
{
    class Program
    {
        private double PI;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.Write("Ingresa tu Nombre: ");
            var Nombre = Console.ReadLine();
            Console.Clear();

            //Tipos de Variables

            int i = 1; //Entero
            string a = "a"; //Cadenas de Texto
            double b = 1.99; //Numeros con Decimal
            float c = 1.99f; // Numeros punto Flotante
            char d = 'd'; // Caracter
            bool e = false; //Booleanos
            const string s = "Hola Mundo"; // Constantes
            long l = 1000000000000L; // Numeros enteros > 2147583647

            //Casting
            double r = 9.18;
            int i2 = (int)l;
            //Metodos Convert
            //Convert.ToInt32(s);Convert.ToBoolean(s);Convert.ToDouble(s); etc..

            /*Operadores
             * 
            + Addition
            - Subtraction
            * Multiplication
            / Division
            % Modulus
            ++ Increment
            -- Decrement
            */

            /* Operadores de Asignacion 
             
             = | x = 5 |x = 5

             */


            Console.ForegroundColor = ConsoleColor.Black;
            ConsoleColor Color;
            Color = Console.ForegroundColor;
            Console.BackgroundColor = ConsoleColor.White;
            
            //Comentario
            /*
            var PI = 3.1416;
            int valorAboslutoPI = Convert.ToInt32(PI); */



        }
    }
}
