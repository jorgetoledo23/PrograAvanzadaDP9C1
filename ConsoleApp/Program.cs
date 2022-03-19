using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.Write("Ingresa tu Nombre: ");
            var Nombre = Console.ReadLine();
            Console.Clear();

            //Tipos de Variables
            // Usar var para inferir el tipo siempre y cuando se asigne valor en la misma linea

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
            += | x += 3 | x = x + 3
            -= | x -= 3 | x = x - 3
            *= | x *= 3 | x = x * 3
            /= | x /= 3 | x = x / 3
            %= | x %= 3 | x = x % 3
            += | x += 3 | x = x + 3

             */


            /* Operadores de Comparacion
             
            == Igual A
            != No Igual A
            > Mayor Que
            < Menor Que
            >= Mayor o Igual Que
            <= Menor o Igual Que            
             
             */

            /* Operadores Logicos
            
            && Logico Y
            || Logico OR
            ! Logico NOT
             
             */
            /*
            int i3 = 1;
            i3 ++ ;
            ++ i3 ;

            int i4 = 1;
            
            int i5 = ++ i4;
            Console.WriteLine(i5);  //(2)

            i4 = 1;
            int i6 = i4++;
            Console.WriteLine(i6); // (1)
            */


            Console.ForegroundColor = ConsoleColor.Black;
            ConsoleColor Color;
            Color = Console.ForegroundColor;
            Console.BackgroundColor = ConsoleColor.White;


            //IF Statement
            if (true) { 
            Console.WriteLine(2);
            Console.WriteLine(3); }
            else if (true)
            Console.WriteLine(2);
            else
            Console.WriteLine(3);
            

            // If una linea
            int time = 10;
            string resultado = (time < 12) ? "Buenos Dias" : "Buenas Tardes";
            if (time < 12) Console.WriteLine("Buenos Dias");

            // While
            int counter = 0;
            while (counter < 10)
            {
                Console.WriteLine($"Hello World! The counter is {counter}");
                counter++;
            }

            //Do While
            int counter2 = 0;
            do
            {
                Console.WriteLine($"Hello World! The counter is {counter}");
                counter++;
            } while (counter2 < 10);

            //Ciclo For

            for (int counter3 = 0; counter3 < 10; counter3++)
            {
                Console.WriteLine($"Hello World! The counter is {counter3}");
            }

            string mes = "Enero";
            switch (mes)
            {
                case "Enero":
                    Console.WriteLine("Verano");
                    break;
                case "Febrero":
                    Console.WriteLine("Verano");
                    break;

                default:
                    Console.WriteLine("Primavera");
                    break;
            }


        }
    }
}
