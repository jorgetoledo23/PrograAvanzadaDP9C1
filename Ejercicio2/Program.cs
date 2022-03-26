using System;
using System.Collections.Generic;

namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
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

            PeriodoTiempo periodoTiempo = new PeriodoTiempo();
            Console.Write("Ingresa una Hora: (0-24)");
            periodoTiempo.Horas = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Tiempo en horas es: {periodoTiempo.Horas}");*/
            /*
            var cliente = new Cliente();
            {
                Nombre = "juAn",
                Apellido = "x",
                Correo = "y"
            };*/
            
            //cliente.Nombre = "asdasd";
            //Console.WriteLine(cliente.Nombre);

            var Vendedor = new Vendedor("aaaa", "bbbb");
            Console.WriteLine(Vendedor.Apellido);

            Reponedor reponedor = new Reponedor()
            {
                Apellido = "",
                Nombre = "",
                Correo = "",
                numCredencial = 111,
                Rut = "",
                Telefono = ""
            };

            
            Contratista contratista = new Contratista()
            {
                Apellido = "",
                Nombre = "",
                Correo = "",
                numContrato = "HFS-12331",
                Rut = "",
                Telefono = ""
            };
            Console.WriteLine(reponedor.ToString());
            Console.WriteLine(contratista.ToString());

        }

    }

    public class Cliente
    {
        private string _nombre;

        public string Nombre { get { return _nombre; } 
            set { 
                _nombre = char.ToUpper(value[0]) + value.Substring(1).ToLower();  
            } }
        public string Apellido { get; set; }
        public string Correo { get; set; }  

        public override string ToString()
        {
            return $"Nombre: {Nombre} Apellido: {Apellido} Correo: {Correo}";
        }
    }

    class Vendedor
    {
        private string _nombre;
        private string _apellido;
        public Vendedor(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido
        {
            get => _apellido;
            set { _apellido = char.ToUpper(value[0]) + value.Substring(1).ToLower(); }
        }
    }


    class PeriodoTiempo
    {
        private double _segundos;

        public double Horas {
            get { return _segundos / 3600; } 
            
            set {
                if (value < 0 || value > 24)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} debe estar entre 0 y 24.");
                _segundos = value * 3600;
            }
        }
    }




}
