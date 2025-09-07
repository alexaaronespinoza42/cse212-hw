public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        //1.- Creamos una lista dinamica (int) donde iremos guardando los resultados paso a paso
        List<int> result = new List<int>();

        //2.- Estas 2 variables son indices que nos dicen en que posicion vamos en cada lista
        int pos1 = 0; // Comienza en la posicion 0 de list1
        int pos2 = 0; // Comienza en la posicion 0 de list2

        //3.- Recorremos cada valor del arreglo selector
        foreach (int s in select)
        {
            // Si el valor actual del selector es 1
            if (s == 1)
            {
                //agregamos el valor de list1 en la posicion actual (pos1) al resultado
                result.Add(list1[pos1]);

                //no olvidemos que tenemos que mover el indice de list1 hacia adelante (para la proxima vez)
                pos1++;
            }
            // si el valor actual del selector es 2
            else if (s == 2)
            {
                // agregamos el valor de list 2 en la posicion actual (pos2) al reusltado
                result.Add(list2[pos2]);

                //Movemos el indice de list2 hacia adelante
                pos2++;
            }
            
        }

        //finalmente volvemos hacia la lista dinamica "result" en un arreglo (array) y lo devolvemos
        return result.ToArray();
    }
}