public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // 1. Create a new array of doubles with the given 'length'.
        // 2. Iterate from 0 to 'length' (exclusive).
        // 3. In each iteration, calculate the multiple of 'number' by the current index + 1.
        // 4. Assign the calculated multiple to the corresponding index in the array.
        // 5. Return the array.

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // 1.  Check if the list is null or empty. If so, return immediately.
        // 2.  Calculate the effective rotation amount by taking the modulo of `amount` with the list's count. This handles cases where `amount` is larger than the list's size.
        // 3.  If the effective rotation amount is 0, return immediately (no rotation needed).
        // 4.  Use `GetRange` to extract the last `amount` elements from the list.
        // 5.  Use `RemoveRange` to remove the last `amount` elements from the original list.
        // 6.  Use `InsertRange` to insert the extracted elements at the beginning of the list.

        if (data == null || data.Count == 0) return;
        int rotationAmount = amount % data.Count;
        if (rotationAmount == 0) return;
        List<int> rotatedPart = data.GetRange(data.Count - rotationAmount, rotationAmount);
        data.RemoveRange(data.Count - rotationAmount, rotationAmount);
        data.InsertRange(0, rotatedPart);
    }
}
