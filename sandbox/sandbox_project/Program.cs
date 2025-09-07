using System; // Importa el espacio de nombres System, que incluye funcionalidades como Console.
using System.Collections.Generic; // Importa el espacio de nombres que contiene la clase List<T>.

public class Program
{
    // Método principal donde inicia la ejecución del programa.
    static void Main(string[] args)
    {
        // Paso 1: Crear un arreglo dinámico (List) con 4 elementos iniciales.
        // La lista 'shoppingList' almacenará cadenas de texto (strings).
        var shoppingList = new List<string> { "pan", "leche", "mantequilla", "huevos" };

        // Mostrar el mensaje de la lista inicial de compras.
        Console.WriteLine("Lista inicial de compras: ");
        // Llamamos al método 'MostrarLista' para imprimir los elementos de la lista en la consola.
        MostrarLista(shoppingList);

        // Paso 2: Agregar el elemento "cereal" a la lista.
        // La lista 'shoppingList' se redimensionará automáticamente si es necesario.
        shoppingList.Add("cereal");

        // Mostrar el mensaje de la lista después de agregar el "cereal".
        Console.WriteLine("\n Lista despues de agregar cereal: ");
        // Llamamos a 'MostrarLista' nuevamente para imprimir la lista actualizada.
        MostrarLista(shoppingList);

        // Paso 3: Eliminar el elemento "leche" de la lista.
        // El método 'Remove' busca y elimina la primera ocurrencia del elemento "leche" en la lista.
        shoppingList.Remove("leche");

        // Agregar "leche" al final de la lista usando el método 'Add'.
        shoppingList.Add("leche");

        // Mostrar el mensaje de la lista final después de mover "leche" al final.
        Console.WriteLine("\n Lista final despues de mover la leche al final: ");
        // Llamamos a 'MostrarLista' para mostrar cómo ha quedado la lista tras mover "leche".
        MostrarLista(shoppingList);
    }

    // Método auxiliar que imprime todos los elementos de una lista en la consola.
    // Este método recibe como parámetro una lista de tipo List<string> llamada 'list'.
    static void MostrarLista(List<string> list)
    {
        // Bucle foreach que recorre cada elemento de la lista 'list'.
        // 'item' será cada uno de los elementos de la lista (en este caso, cadenas de texto).
        foreach (var item in list)
        {
            // Imprime el valor del elemento actual en la consola.
            Console.WriteLine(item);
        }
    }
}

// throw new ArgumentNullException(nameof(data));
// throw -> lanza un error
// new ArgumentNullExcepction(..) -> el tipo de error que indica que el parametro es nulo
// nameof(data) -> pasa el nombre del parametro al error, para que quede claro cual es el problema
// Proposito general -> progeter al metodo, asegurarse de que solo se ejecute con arugmentos validos y dar mensajes calro si algo sale mal