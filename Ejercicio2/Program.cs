using System;
using System.Collections.Generic;

namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> listaEjemplo = new List<string>();

            //Metodo ADD
            listaEjemplo.Add("String");

            //Recorrer Lista
            foreach (var item in listaEjemplo)
            {
                Console.WriteLine(item);
            }
            listaEjemplo.ForEach(cliente => Console.WriteLine(cliente.ToLower()));

            //Acceder a Posicion Especifica (INDEX)
            var primerItem = listaEjemplo[0];

            //Listado vacio
            List<Cliente> listaClientes = new List<Cliente>();

            Cliente juanitoPerez = new Cliente("Juan", "Perez", "a@a.cl");

            listaClientes.Add(juanitoPerez);

            listaClientes.ForEach(cliente => Console.WriteLine(cliente.Nombre));

            Console.WriteLine(juanitoPerez.ToString());
        }

    }

    public class Cliente
    {
        public string Nombre;
        public string Apellido;
        public string Correo;

        public Cliente(string nombre, string apellido, string correo)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Correo = correo;   
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre} Apellido: {Apellido} Correo: {Correo}";
        }
    }
}
