using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks.task;

namespace Tasks.menu
{
    internal class Menu {
        private List<Task> tasks = new List<Task>();

        internal Menu() { 
        }

        internal void buildMenu()
        {
            //Usé este ciclo while para permitirle al usuario agregar varias tareas sin que se cierre el aplicativo
            //cuando el usuario no quiera agregar mas tareas tendrá la opción de salir.
            while (true)
            {


                Console.Clear();
                Console.WriteLine("Mi Lista de Tareas.");
                Console.WriteLine("1.Añadir una tarea.");
                Console.WriteLine("2.Listar todas tarea.");
                Console.WriteLine("3.Marcar una tarea como completada.");
                Console.WriteLine("4.Borrar una tarea.");
                Console.WriteLine("5.Salir.");
                Console.Write("Por favor seleccione una opción(números en pantalla: ");

                string option = Console.ReadLine();

                try
                {
                    switch (option)
                    {
                        case "1":
                            addTask();
                            break;
                        case "2":
                            listTasks();
                            break;
                        case "3":
                            markCompleted();
                            break;
                        case "4":
                            deleteTask();
                            break;
                        case "5":
                            return;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine("Pulse cualquier tecla para seguir");
                Console.ReadKey();
            }
        }

    private void addTask()
    {
        Console.WriteLine("Agregue una descripcion para su tarea: ");
        string description = Console.ReadLine();

        Console.WriteLine("Agregue la fecha limite para su tarea en formato dd/MM/yyyy): ");
        string deadLineInput = Console.ReadLine();
        DateTime? deadLine = null;
            //Aquí agregué una validacion para el campo de fecha
            //si el usuario ingresa un formato incorrecto la consola le dirá que la fecha es inválida y se agregará la tarea sin limite de fecha.
        if (!string.IsNullOrWhiteSpace(deadLineInput))
        {
            if (DateTime.TryParse(deadLineInput, out DateTime date))
            {
                deadLine = date;
            }
            else
            {
                Console.WriteLine("Fecha inválida, se agregará sin fecha limite");
            }
        }

        Task newTask = new Task (description, deadLine);
        tasks.Add(newTask);

        Console.WriteLine("Tarea agregada con éxito.");
    }
    private void listTasks()
    {
        Console.WriteLine("Mis Tareas.");
        if (tasks.Count == 0)
        {
            Console.WriteLine("No se ha guardado ninguna tarea.");
            return;
        }
        //El siguiente contador sirve para mostrar cuales son todas nuestras tareas
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i].toString()}");
        }
    }
    private void markCompleted()
    {
        listTasks();
        Console.WriteLine("Número de tarea a marcar como completada: ");
        if (int.TryParse(Console.ReadLine(), out int number) && number > 0 && number <= tasks.Count)
        {
                //Aqui se edita el estado "Pendiente" que viene por defecto y se actualiza a "Completado"
                tasks[number - 1].setCompleted(true);
                Console.WriteLine("Tarea completada.");
        }
        else
        {
            Console.WriteLine("Esta Tarea no existe, ingrese un numero de tarea válido.");
        }
    }
    private void deleteTask()
       {
        listTasks();
        Console.WriteLine("Ingrese el número de la tarea que quiere borrar: ");
        if (int.TryParse(Console.ReadLine(), out int number) && number > 0 && number <= tasks.Count)
            {
                tasks.RemoveAt(number - 1);
                Console.WriteLine("Tarea borrada.");
            }
            else
            {
                Console.WriteLine("Esta tarea no existe, ingrese un  numero de tarea válido.");
            }
        }
    }
}
