using Aplicacion.Interfaces;
using Aplicacion.Servicios;
using Dominio.Interfaces;
using Infraestructura.Adaptadores;

namespace ArquitecturaHexagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Configuración de dependencias
            IRepositorioTareas repositorioTareas = new RepositorioTareasEnMemoria();
            IServicioTareas servicioTareas = new ServicioTareas(repositorioTareas);

            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("===== Gestión de Tareas =====");
                Console.WriteLine("1. Crear nueva tarea");
                Console.WriteLine("2. Listar tareas pendientes");
                Console.WriteLine("3. Completar tarea");
                Console.WriteLine("4. Listar tareas completadas");
                Console.WriteLine("5. Eliminar tarea");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Ingresa la desción de la tarea: ");
                        var descripcion = Console.ReadLine();
                        servicioTareas.CrearTarea(descripcion);
                        Console.WriteLine("Tarea creada con éxito.");
                        break;

                    case "2":
                        var tareasPendientes = servicioTareas.ObtenerTareasPendientes();
                        Console.WriteLine("=== Tareas Pendientes ===");
                        foreach (var tarea in tareasPendientes)
                        {
                            Console.WriteLine($"ID: {tarea.Id} - {tarea.Descripcion}");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Ingrese el ID de la tarea a completar: ");
                        var idCompletar = Guid.Parse(Console.ReadLine());
                        servicioTareas.CompletarTarea(idCompletar);
                        Console.WriteLine("Tarea completada.");
                        break;

                    case "4":
                        var tareasCompletadas = servicioTareas.ObtenerTareasCompletas();
                        Console.WriteLine("=== Tareas Completadas ===");
                        foreach (var completadas in tareasCompletadas)
                        {
                            Console.WriteLine($"ID: {completadas.Id} - {completadas.Descripcion}");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Ingrese el ID de la tarea a eliminar: ");
                        var idEliminar = Guid.Parse(Console.ReadLine());
                        servicioTareas.EliminarTarea(idEliminar);
                        Console.WriteLine("Tarea eliminada.");
                        break;

                    case "0":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción invalida.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}

