using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MétodosYProcedimientos
{
    internal class Inventario
    {
        //Variables globales.
        static string[] nombre = new string[3];
        static float[] notas = new float[3];
        static byte i = 0; // Para la posición del arreglo.
        static string continuar = "s";
        public static void menu()
        {
            byte opc = 0;

            do
            {
                Console.WriteLine("1- Agregar estudiantes.");
                Console.WriteLine("2- Buscar estudiante.");
                Console.WriteLine("3- Asignar nota al estudiante.");
                Console.WriteLine("4- Imprimir estudiante con su nota.");
                Console.WriteLine("5- Modificar nombre.");
                Console.WriteLine("6- Eliminar nombre.");
                Console.WriteLine("7- Salir.");
                Console.WriteLine("Digite una opción.");
                opc = byte.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        AgregarEstudiantes();
                        break;
                    case 2:
                        BuscarEstudiantes();
                        break;
                    case 3:
                        AsignarNotas();
                        break;
                    case 4:
                        ImprimirDatos();
                        break;
                    case 5:
                        ModificarNombres();
                        break;
                    case 6:
                        BorrarNombres();
                        break;
                    default:
                        break;
                }

                Console.Clear();

            } while (opc != 7);
        }
        static void AgregarEstudiantes()
        {

            do
            {
                if (i == 3)
                {
                    Console.WriteLine("**Solo están permitidos 3 alumnos**");
                    Console.ReadKey();
                    break;
                }

                Console.Clear();
                Console.WriteLine("Digite el nombre:");
                nombre[i] = Console.ReadLine();
                i++;
                Console.WriteLine("¿Desea continuar? s/n");
                continuar = Console.ReadLine().ToLower();

            } while (!continuar.Equals("n"));

        }

        static void BuscarEstudiantes()
        {
            Console.Clear();
            Console.WriteLine("Digite el nombre del estudiante a localizar:");
            string nombre = Console.ReadLine();
            Boolean comp = false;

            for (int i = 0; i < Inventario.nombre.Length; i++)
            {
                if (nombre.Equals(Inventario.nombre[i]))
                {
                    Console.WriteLine($"Estudiante registrado en el espacio [{i}].");
                    comp = true;
                }
            }
            if (comp == false)
            {
                Console.WriteLine("Estudiante no se encuentra registrado.");
            }
            Console.ReadKey();
        }

        static void AsignarNotas()
        {
            Console.Clear();
            Console.WriteLine("Digite el nombre del estudiante a asignar la nota:");
            string nombre = Console.ReadLine();
            Boolean comp = false;

            for (int i = 0; i < Inventario.nombre.Length; i++)
            {
                if (nombre.Equals(Inventario.nombre[i]))
                {
                    Console.WriteLine("¿Qué nota desea registrar? 1 - 100");
                    Inventario.notas[i] = float.Parse(Console.ReadLine());
                    if (Inventario.notas[i] > 100 | Inventario.notas[i] < 1)
                    {
                        Console.WriteLine("Por favor ingrese un valor correcto. 1 - 100");
                        Inventario.notas[i] = 0;
                    }
                    else
                    {
                        Console.WriteLine("**Nota registrada de manera exitosa**");
                    }
                    comp = true;
                }
            }

            if (comp == false)
            {
                Console.WriteLine("Estudiante no se encuentra registrado.");
            }
            Console.ReadKey();

        }

        static void ImprimirDatos()
        {
            Console.Clear();
            Console.WriteLine("**Desglose de información**");
            for (int i = 0; i < Inventario.nombre.Length; i++)
            {
                if (Inventario.nombre[i] == null)
                {
                    Console.WriteLine($"No hay ningún estudiante registrado en el espacio [{i}].");
                }
                else
                {
                    if (Inventario.notas[i] == 0)
                    {
                        Console.WriteLine($"{Inventario.nombre[i]} aún no tiene una nota registrada.");
                    }
                    else
                    {
                        Console.WriteLine($"{Inventario.nombre[i]} tiene una nota de {Inventario.notas[i]}.");
                    }
                }
            }

            Console.ReadKey();

        }

        static void ModificarNombres()
        {
            Console.Clear();
            Console.WriteLine("**Nombres registrados**");
            for (int i = 0; i < Inventario.nombre.Length; i++)
            {
                if (Inventario.nombre[i] != null)
                {
                    Console.WriteLine($"Estudiante: {Inventario.nombre[i]} [{i}].");
                }

            }
            Console.WriteLine("Digite el número de espacio el cual desea modificar.");
            i = byte.Parse(Console.ReadLine());

            if (Inventario.nombre[i] == null)
            {
                Console.WriteLine("**No se puede modificar un espacio vacío**");
            }
            else
            {
                Console.WriteLine("Ingrese el nombre que remplazará al anterior:");
                Inventario.nombre[i] = (Console.ReadLine());
                Console.WriteLine("**Remplazado exitosamente**");
            }

            Console.ReadKey();

        }

        static void BorrarNombres()
        {
            Console.Clear();
            Console.WriteLine("**Nombres registrados**");
            for (int i = 0; i < Inventario.nombre.Length; i++)
            {
                if (Inventario.nombre[i] != null)
                {
                    Console.WriteLine($"Estudiante: {Inventario.nombre[i]} [{i}].");
                }

            }

            Console.WriteLine("Digite el número de espacio el cual desea eliminar.");
            i = byte.Parse(Console.ReadLine());

            if (Inventario.nombre[i] == null)
            {
                Console.WriteLine("**No hay nada en este espacio**");
            }
            else
            {
                Inventario.nombre[i] = null;
                Console.WriteLine("**Eliminado exitosamente**");
            }

            Console.ReadKey();

        }

    }



}