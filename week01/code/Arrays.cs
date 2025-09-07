using System.ComponentModel.DataAnnotations;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>

    public static double[] MultiplesOf(double number, int length)

    // This method returns an array of multiples of a given number.
    // 'number' is the base number and 'length' is how many multiples we want to generate
    // Example: MultiplesOf(3,5) -> {3,6,9,12,15}

    {
        // =========================================
        // 1) Creation of the result array
        // =========================================    
        // An array in C# needs a fixed size when we create it
        // Since we want "length" number of multiples, we create an array
        // with exactly "length" positions
        // All of these positions start with the default value (0,0 in this case)

        double[] result = new double[length];

        // =========================================
        // 2) Fill the array with multiples
        // =========================================
        // We use a "for" loop because we want to repeat a block of code
        // exactly "length" times , once for each position of the arrray
        // The loop give us a counter 'i' that starts in 0 and goes up to length-1

        for (int i = 0; i < length; i++)
        {

            // Inside this loop  we calculate which multiple corresponds.
            // We use (i+1) because:
            // - In this first iteration, i = 0, but we want 1 * number and not 0 * number
            // - In the second iteration, i = 1, and we want 2 * number
            // In general the kth multiple is calculates as number * k
            // and since 'i' starts at 0, we use (i+1)

            result[i] = number * (i + 1);

            // In each iteration, we save the multiple in the position 'i' of the array
            // Example: if number = 3 and length = 5:
            // i = 0 -> result[0] = 3 * (0 + 1) = 3
            // i = 1 -> result[1] = 3 * (1 + 1) = 6
            // i = 2 -> result[2] = 3 * (2 + 1) = 9
            // i = 3 -> result[3] = 3 * (3 + 1) = 12
            // i = 4 -> result[4] = 3 * (4 + 1) = 15
        }


        return result; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // This method receives:
        // 'data': a list of integers that we want to rotate
        // 'amount': how many positions to the right the list should be rotated
        // The original list is modified directly (nothing is returned)


        // =========================================
        // 1) Validate that the list isnt null
        // =========================================
        // Is a good practice to verify that the list exists before manipulating it
        // If 'data' were null and we tried to access its elements the program would crash
        if (data == null)
            throw new ArgumentNullException(nameof(data));
        // throws an error indicating that the list cannot be null

        // =========================================
        // 2) Get the size of the list
        // =========================================
        // 'n' stores how many elements are in the list
        // this will help us to calculate positions and limits in the rotation
        int n = data.Count;

        // =========================================
        // 3) Cases where no action is required
        // =========================================
        if (n <= 1)
            return;
        // if the list has 0 or 1 element, rotating it doesnt change anything. No need to continue

        // =========================================
        // 4) Normalize 'amount'
        // =========================================
        // Although the statement says that 'amount' is between '1' and 'n', it is good practice
        amount = amount % n;
        // This secures that if someone passes an 'amount' equal to the size of the list
        // or greater, we wont rotate too much, because rotating 'n' positions returns the same list
        if (amount == 0)
            return; // if amount is multiple of 'n', there is no rotation to perform

        // =========================================
        // 5) Take the last 'amount' elements
        // =========================================
        //'GetRange(start, count)' returns a copy of a range from the list
        // We want the last 'amount' elements to be moved to the beginning
        // Syntax: list.GetRange(startIndex, count)
        // -startIndex: from which position of the list i want to copy
        // -count: how many elements to copy from that index

        // =============== In this Case ===========
        // 'n' is the total size of the list (data.Count)
        // 'amount' is how many elements we want to move to the front
        // 'n-amount' calculates the index of the FIRST element that we want to copy
        // Ex: if n = 9 and amount = 5 ---> n - amount = 4
        // That means we start at index 4 (the 5th element, because the list starts at 0)
        // 'amount' tell us how many elements we want to take from there (5 in this ex.)

        // So, if data = {1,2,3,4,5,6,7,8,9}
        // n = 9 , amount = 5 -> n - amount = 4
        // data.GetRange(4,5) returns {5,6,7,8,9}

        // Important: GetRange returns a **new list** (a copy of this elements)
        // it doesnt modify the original list. Thats why we store it in a variable named 'tail'
        List<int> tail = data.GetRange(n - amount, amount);
        // EX: data = {1,2,3,4,5,6,7,8,9}, amount = 5
        // n - amount = 9 - 5 = 4
        // tail = {5,6,7,8,9}-> these are the elements that will come first

        // =========================================
        // 6) Eliminate this elements from the end
        // =========================================
        // We remove the last 'amount' elements from the original list
        // This leave us with the first part, which will be moved behind 'tail'
        data.RemoveRange(n - amount, amount);
        // After this step: data = {1,2,3,4}

        // =========================================
        // 7) Insert 'tail' to the beginning
        // =========================================
        // 'InsertRange(index, list)' inserts allelements from another list at the specified position
        // We place 'tail' at the beggining (index 0) of 'data'
        data.InsertRange(0, tail);
        // Final result: data = {5,6,7,8,9,1,2,3,4} -> list rotated correctly

    }




}
