def solve_knapsack(values, weights, capacity):
    # create a 2D array to store the maximum value at each weight capacity
    # up to the current item being considered
    max_values = [[0 for _ in range(capacity + 1)] for _ in range(len(values) + 1)]

    for i in range(1, len(values) + 1):
        for j in range(capacity + 1):
            # if the current item is too heavy to fit in the knapsack,
            # use the maximum value without including the current item
            if weights[i - 1] > j:
                max_values[i][j] = max_values[i - 1][j]
            else:
                # otherwise, take the maximum of either including the current item
                # or not including it
                max_values[i][j] = max(max_values[i - 1][j], max_values[i - 1][j - weights[i - 1]] + values[i - 1])

    # the maximum value will be in the bottom right corner of the array
    return max_values[len(values)][capacity]
