/* Crear una APP de Consola, en la que se puedan ingresar x cantidad de Empleados y
 * distribuirlos segun su tipo. (Vendedor, Reponedor, Contratista)
 * Los atributos para ellos son Rut, Nombre, Apellido, Correo, Telefono
 * Lo que los diferencia es que el:
 * Vendedor tiene un Codigo de Vendedor
 * Contratista tiene Numero Contrato
 * Reponedor tiene un Numero de Credencial
 * La App tiene que tener la capacidad de Mostrar los Empleados segun su tipo.
 * */
using Empleados;

string? opcion;
List<Persona> listaPersonal = new List<Persona>();


do{
    Console.Clear();    
    Console.WriteLine("Seleccione una Opcion -> ");
    Console.WriteLine("1-Ingresar Empleado");
    Console.WriteLine("2-Listar Empleados");
    Console.WriteLine("0-Salir");
    Console.WriteLine("Opcion: ");
    opcion = Console.ReadLine();
    switch (opcion)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("Ingrese los Datos Solicitados");
            Console.Write("Rut: ");
            string? rut = Console.ReadLine();
            Console.Write("Nombre: ");
            string? nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            string? apellido = Console.ReadLine();
            Console.Write("Correo: ");
            string? correo = Console.ReadLine();
            Console.Write("Telefono: ");
            string? telefono = Console.ReadLine();

            string? tipoOpcion;
            string? tipo;
            string? codigo;
            do
            {
                Console.Clear();
                Console.WriteLine("1-Vendedor");
                Console.WriteLine("2-Contratista");
                Console.WriteLine("3-Reponedor");
                Console.Write("Seleccione Tipo: ");
                tipoOpcion = Console.ReadLine();
            } while (tipoOpcion != "1" && tipoOpcion != "2" && tipoOpcion != "3");
            
            switch (tipoOpcion)
            {

                case "1":

                    tipo = "Vendedor";
                    Console.WriteLine("Ingrese Codigo Vendedor: ");
                    codigo = Console.ReadLine();
                    Vendedor V = new Vendedor()
                    {
                        Nombre = nombre,
                        Apellido = apellido,
                        Correo = correo,
                        Telefono = telefono,
                        Rut = rut,
                        Codigo = codigo
                    };
                    listaPersonal.Add(V);
                    break;
                case "2":
                    tipo = "Contratista";
                    Console.WriteLine("Ingrese N° Contrato: ");
                    codigo = Console.ReadLine();
                    Contratista C = new Contratista()
                    {
                        Nombre = nombre,
                        Apellido = apellido,
                        Correo = correo,
                        Telefono = telefono,
                        Rut = rut,
                        numContrato = codigo
                    };
                    listaPersonal.Add(C);
                    break;
                case "3":
                    tipo = "Reponedor";
                    Console.WriteLine("Ingrese Codigo Credencial: ");
                    codigo = Console.ReadLine();
                    Reponedor R = new Reponedor()
                    {
                        Nombre = nombre,
                        Apellido = apellido,
                        Correo = correo,
                        Telefono = telefono,
                        Rut = rut,
                        numCredencial = codigo
                    };
                    listaPersonal.Add(R);
                    break;
            }

            Console.WriteLine("Empleado Agregado Correctamente! Presione una Tecla para Continuar...");
            Console.ReadLine(); 

            break;

        case "2":
            //Listar Empleados
            do
            {
                Console.WriteLine("1-Vendedores");
                Console.WriteLine("2-Contratistas");
                Console.WriteLine("3-Reponedores");
                Console.WriteLine("4-Todos");
                Console.Write("Seleccione: ");
                tipoOpcion = Console.ReadLine();
            } while (tipoOpcion != "1" && tipoOpcion != "2" && tipoOpcion != "3" && tipoOpcion != "4") ;

            Console.Clear();
            switch (tipoOpcion)
            {
                case "1":
                    foreach (var P in listaPersonal){
                        if (P.GetType().ToString().Equals("Empleados.Vendedor"))
                        {
                            Console.WriteLine(P.ToString());
                        }
                    }
                    Console.WriteLine("Empleados Listados! Presione una Tecla para Continuar...");
                    Console.ReadLine();

                    break;
                case "2":
                    foreach (var P in listaPersonal)
                    {
                        if (P.GetType().Equals("Empleados.Contratista"))
                        {
                            Console.WriteLine(P.ToString());
                        }

                    }
                    Console.WriteLine("Empleados Listados! Presione una Tecla para Continuar...");
                    Console.ReadLine();

                    break;
                case "3":
                    foreach (var P in listaPersonal)
                    {
                        if (P.GetType().Equals("Empleados.Reponedor"))
                        {
                            Console.WriteLine(P.ToString());
                        }

                    }
                    Console.WriteLine("Empleados Listados! Presione una Tecla para Continuar...");
                    Console.ReadLine();

                    break;

                case "4":
                    foreach (var P in listaPersonal)
                    {
                        Console.WriteLine(P.ToString());
                    }
                    Console.WriteLine("Empleados Listados! Presione una Tecla para Continuar...");
                    Console.ReadLine();

                    break;
            }

            

            break;

    }
} while (opcion!="0");

