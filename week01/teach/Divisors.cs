public static class Divisors {
    /// <summary>
    /// Entry point for the Divisors class
    /// </summary>
    public static void Run() {
        List<int> list = FindDivisors(80);
        Console.WriteLine("<List>{" + string.Join(", ", list) + "}"); // <List>{1, 2, 4, 5, 8, 10, 16, 20, 40}
        List<int> list1 = FindDivisors(79);
        Console.WriteLine("<List>{" + string.Join(", ", list1) + "}"); // <List>{1}
    }

    /// <summary>
    /// Create a list of all divisors for a number including 1
    /// and excluding the number itself. Modulo will be used
    /// to test divisibility.
    /// </summary>
    /// <param name="number">The number to find the divisor</param>
    /// <returns>List of divisors</returns>
    private static List<int> FindDivisors(int number) {
        // 1.- Se crea una lista de tipo INT para almacenar los divisores del numero
        // esta lista se llenara de los divisores de "number" excluyendolo al "number" mismo.
        List<int> results = new List<int>();

        // 2.- Creamos un bucle que va desde 1 hasta number - 1
        // esto pasa porque no debemos incluir "number" en sus propios divisores
        // Si iteramos hasta el número mismo (es decir, hasta 80 en este caso), también agregaríamos el número 80 a la lista, lo cual no queremos.
        // Por eso es que usamos el bucle con la condición i < number. Esto asegura que el bucle va de 1 hasta number - 1 (es decir, desde 1 hasta 
        // 79 en el caso de 80), sin incluir el número 80
        for (int i = 1; i < number; i++)
        {
            // 3.- dentro del bucle usamos el operador % para ver si "i" es un divisor de number
            // el operador % calcula el residuo de la division "number/i"
            // si el residuo es 0, significa que "i" divide a "number perfectamente
            if (number % i == 0)
            {
                // 4. si la condicion se cumple, se agrega "i" a la lista de results
                // esto significa que "i" es un divisor de number 
                results.Add(i);
            }
        }

        // 5.- despues de que el bucle termine se devuelve la lista "results"
        // esta lista contiene todos los divisores de "number", excluyendo al number mismo (como hablamos antes)
        return results;
    }
}
