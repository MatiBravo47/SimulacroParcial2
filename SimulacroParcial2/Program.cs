using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SimulacroParcial2
{
    //Creo estructura
    struct Videojuego 
    {
        public string nombre; //Nombre del videojuego
        public char categoria; //Categoria del videojuego
        public double precio; //Precio del videojuego
        public int edadMinima; //Edad minima recomendada
        public bool disponible; //Disponibilidad del juego
    }

    class Program
    {
        //Lista de tipo estructura para almacenar los videojuegos
        static List<Videojuego> videojuegos = new List<Videojuego>();

        //Arreglo para almacenar los nombres de las empresas
        static string[] empresas = { "Desarrollos fantasticos", "Gaming Studio", "Pixel Creations" };
        
        //Matriz para registrar las ventas de videojuegos (filas: empresas, columnas: meses)
        static int[,] ventas = new int[empresas.Length,12]; //12 meses del anio
        

        static void Main(string[] args)
        {
            // Agregar videojuegos predefinidos
            videojuegos.Add(new Videojuego { nombre = "Aventuras Épicas", categoria = 'A', precio = 49.99, edadMinima = 10, disponible = true });
            videojuegos.Add(new Videojuego { nombre = "RoboWars", categoria = 'R', precio = 59.99, edadMinima = 12, disponible = false });
            videojuegos.Add(new Videojuego { nombre = "Puzzle Mania", categoria = 'D', precio = 19.99, edadMinima = 5, disponible = true });
            videojuegos.Add(new Videojuego { nombre = "Simulador de Vida", categoria = 'A', precio = 39.99, edadMinima = 16, disponible = true });
            videojuegos.Add(new Videojuego { nombre = "Carreras Extrema", categoria = 'R', precio = 29.99, edadMinima = 7, disponible = true });


            int opcion;

            do
            {
                //Mostrar el menu principal
                Console.WriteLine("Menu principal");
                Console.WriteLine("1. Agregar Videojuego");
                Console.WriteLine("2. Buscar Videojuego");
                Console.WriteLine("3. Listar Videojuego");
                Console.WriteLine("4. Ordenar Videojuegos por precio");
                Console.WriteLine("5. Registrar ventas");
                Console.WriteLine("6. Calcular promedio de precio");
                Console.WriteLine("7. Filtrar por Edad minima");
                Console.WriteLine("0. Salir");

                //Leer la opcion elegida
                opcion = int.Parse(Console.ReadLine());

                //Ejecutar la opcion seleccionada
                switch (opcion)
                {
                    case 1:
                        AgregarVideojuego();
                        break;
                    case 2:
                        BuscarVideojuego();
                        break;
                    case 3:
                        ListarVideojuegos();
                        break;
                    case 4:
                        OrdenarVideojuegosPorPrecio();
                        break;
                    case 5:
                        RegistrarVentas();
                        break;
                    case 6:
                        CalcularPromedioPrecio();
                        break;
                    case 7:
                        FiltrarPorEdadMinima();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa..");
                        break;
                    default:
                        Console.WriteLine("Opcion no valida, por favor intente nuevamente.");
                        break;

                }
            } while (opcion != 0); //Continuar hasta que el usuario elija salir
        }

        //1. Funcion para agregar un videojuego(Verificar ingresos y agregar elemento a una lista)
        static void AgregarVideojuego()
        {
            //Crea una nueva variable tipo estructura
            Videojuego nuevoVideojuego;
            bool existe = false;

            //Leer los datos del videojuego
            Console.WriteLine("Ingrese el nombre del videojuego");
            nuevoVideojuego.nombre = Console.ReadLine();

            //Verificar que el nombre no este repetido
            foreach (var juego in videojuegos)
            {
                //Controla si los juegos existes son iguales al nuevo juego ingresado, compara el string ignorando las mayusculas.
                if(juego.nombre.Equals(nuevoVideojuego.nombre, StringComparison.OrdinalIgnoreCase))
                {
                    existe = true;
                    break;
                }
            }

            //Si el videojuego ya existe, notificar al usuario
            if (existe)
            {
                Console.WriteLine("El videojuego ya existe,");
                return;
            }

            //Leer el resto de los datos
            Console.Write("Ingrese la categoria (A/R/D)");
            //Leer string convertido a mayus
            nuevoVideojuego.categoria = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            Console.Write("Ingrese el precio");
            nuevoVideojuego.precio = double.Parse(Console.ReadLine());
            
            Console.Write("Ingrese la edad minima recomendada: ");
            nuevoVideojuego.edadMinima = int.Parse(Console.ReadLine());

            Console.Write("Esta disponible?(true/false): ");
            nuevoVideojuego.disponible = bool.Parse(Console.ReadLine());

            //Agregar el nuevo videojuego a la lista
            videojuegos.Add(nuevoVideojuego);
            Console.WriteLine("Videojuego agregado exitosamente");
        }

        //2. Funcion para buscar un videojuego(Busqueda con foreach)
        static void BuscarVideojuego()
        {
            Console.Write("Ingrese el nombre del videojuego a buscar: ");
            string nombreBuscar = Console.ReadLine();
            bool encontrado = false;

            //Buscar el videojuego en la lista
            foreach (var juego in videojuegos)
            {
                if(juego.nombre.Equals(nombreBuscar, StringComparison.OrdinalIgnoreCase))
                {
                    //Mostrar la informacion del videojuego encontrado
                    Console.WriteLine($"Nombre: {juego.nombre}, Categoria:{juego.categoria}, Precio:{juego.precio}, Edad Minima: {juego.edadMinima}, Disponible: {juego.disponible} ");
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
                Console.WriteLine("Videojuego no encontrado");
        }

        //3. Funcion para listar todos los videojuegos(Mostrar por pantalla con foreach)
        static void ListarVideojuegos() 
        {
            Console.WriteLine("Lista de videojuegos");
            //Usar un bucle foreach para recorrer la lista de videojuegos
            foreach (var juego in videojuegos)
            {
                Console.WriteLine($"Nombre:{juego.nombre}, categoria:{juego.categoria}, precio:{juego.precio},edad minima: {juego.edadMinima}, Disponible:{juego.disponible}");
            }
        }

        //4. Funcion para ordenar los videojuegos por precio(Ordenar por burbujeo)
        static void OrdenarVideojuegosPorPrecio()
        {
            //Recorrer todo el arreglo
            for (int i = 0; i < videojuegos.Count -1;i++)
            {
                //Hacer la comparativa, se le resta uno porque en el ultimo elemento, no hay elemento siguiente
                for (int j = 0; j < videojuegos.Count - i -1; j++)
                {
                    //Comparar precios para el ordenamiento burbuja
                    if (videojuegos[j].precio > videojuegos[j + 1].precio) 
                    {
                        //Intercambiar videojuegos
                        //Guarda el mayor en una variable temporal 
                        var temp = videojuegos[j];
                        //Guarda el menor en la anterior
                        videojuegos[j] = videojuegos[j + 1];
                        //Guarda el mayor en el siguiente
                        videojuegos[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("Videojuegos ordenados por precio exitosamente");
        }
        
        //5. Funcion para registrar ventas de videojuegos(Agregar elementos a una matriz)
        static void RegistrarVentas()
        {
            //Mostrar las empresas disponibles
            Console.WriteLine("Registrar ventas");
            for (int i = 0; i< empresas.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {empresas[i]}");
            }

            //Elegir una empresa para registrar ventas
            Console.WriteLine("Seleccione una empresa (1-3)");
            int indiceEmpresa = int.Parse(Console.ReadLine()) - 1;

            //Verificar que el indice sea valido 
            if (indiceEmpresa < 0 || indiceEmpresa >= empresas.Length)
            {
                Console.WriteLine("Empresa no valida");
                return;
            }

            //Registrar ventas para cada mes
            for (int mes = 0; mes < 12; mes++) 
            {
                Console.WriteLine($"Ingrese la cantidad de juegos vendidos en {mes + 1}mes:");
                ventas[indiceEmpresa, mes] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Ventas registradas exitosamente.");
        }

        //6. Funcion para calcular el promedio de precios de los videojuegos (Promedio recorriendo con foreach)
        static void CalcularPromedioPrecio() 
        {
            double sumaPrecios = 0;
            int contador = 0;

            //Calcular la suma de precios y contar videojuegos disponibles 
            foreach (var juego in videojuegos)
            {
                if (juego.disponible)
                {
                    sumaPrecios += juego.precio;
                    contador++;
                }
            }

            //Mostrar el promedio si hay videojuegos disponibles 
            if (contador > 0)
            {
                double promedio = sumaPrecios / contador;
                Console.WriteLine($"El precio promedio de los videojuegos disponibles es: {promedio}");
            }
            else
            {
                Console.WriteLine("No hay videojuegos disponibles para calcular el promedio.");
            }
        }

        //7. Funcion para filtrar videojuegos por edad minima(Recorrido con foreach con condicion)
        static void FiltrarPorEdadMinima() 
        {
            Console.WriteLine("Ingrese la edad minima");
            int edadMaxima = int.Parse(Console.ReadLine());

            Console.WriteLine("Videojuegos filtrados");
            //Usar un bucle foreach para filtrar y mostrar videojuegos
            foreach (var juego in videojuegos) 
            {
                if (juego.edadMinima <= edadMaxima) 
                {
                    Console.WriteLine($"Nombre{ juego.nombre}, Edad minima:{ juego.edadMinima}");
                }
            }
        }
    }
}
