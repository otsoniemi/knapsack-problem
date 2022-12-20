public int SolveKnapsack(int[] values, int[] weights, int capacity)
{
    // create a 2D array to store the maximum value at each weight capacity
    // up to the current item being considered
    int[,] maxValues = new int[values.Length + 1, capacity + 1];

    for (int i = 1; i <= values.Length; i++)
    {
        for (int j = 0; j <= capacity; j++)
        {
            // if the current item is too heavy to fit in the knapsack,
            // use the maximum value without including the current item
            if (weights[i - 1] > j)
            {
                maxValues[i, j] = maxValues[i - 1, j];
            }
            else
            {
                // otherwise, take the maximum of either including the current item
                // or not including it
                maxValues[i, j] = Math.Max(maxValues[i - 1, j], maxValues[i - 1, j - weights[i - 1]] + values[i - 1]);
            }
        }
    }

    // the maximum value will be in the bottom right corner of the array
    return maxValues[values.Length, capacity];
}
