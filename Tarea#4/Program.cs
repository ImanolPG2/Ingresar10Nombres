using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        LinkedList<string> nombres = new LinkedList<string>();

        Console.WriteLine("Ingrese 10 nombres:");

        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Nombre {i + 1}: ");
            string nombre = Console.ReadLine();
            InsertarOrdenado(nombres, nombre);
        }

        Console.WriteLine("\nLista de nombres ordenados alfabéticamente:");
        MostrarLista(nombres);

        Console.Write("\nIngrese el nombre que desea eliminar de la lista: ");
        string nombreAEliminar = Console.ReadLine();
        EliminarNombre(nombres, nombreAEliminar);

        Console.WriteLine("\nLista de nombres después de la eliminación:");
        MostrarLista(nombres);
    }

    static void InsertarOrdenado(LinkedList<string> lista, string nombre)
    {
        if (lista.Count == 0)
        {
            lista.AddFirst(nombre);
        }
        else
        {
            LinkedListNode<string> actual = lista.First;
            while (actual != null && string.Compare(actual.Value, nombre, StringComparison.OrdinalIgnoreCase) < 0)
            {
                actual = actual.Next;
            }

            if (actual == null)
            {
                lista.AddLast(nombre);
            }
            else
            {
                lista.AddBefore(actual, nombre);
            }
        }
    }

    static void MostrarLista(LinkedList<string> lista)
    {
        foreach (string nombre in lista)
        {
            Console.WriteLine(nombre);
        }
    }

    static void EliminarNombre(LinkedList<string> lista, string nombre)
    {
        LinkedListNode<string> actual = lista.First;

        while (actual != null)
        {
            if (actual.Value.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                lista.Remove(actual);
                Console.WriteLine($"El nombre '{nombre}' ha sido eliminado.");
                return;
            }
            actual = actual.Next;
        }

        Console.WriteLine($"El nombre '{nombre}' no se encontró en la lista.");
    }
}
