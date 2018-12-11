using System;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        int left = 0,
            right = input.Length - 1;

        while (left <= right)
        {
            int m = (int)Math.Floor((decimal)((left + right) / 2));

            if (value > input[m])
                left = m + 1;
            else if (value < input[m])
                right = m - 1;
            else
                return m;
        }

        return -1;
    }
}