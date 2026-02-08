using System;
using System.Collections.Generic;
using System.Linq;







using System;
using System.Collections.Generic;
using System.Linq;

public static class LongestIncreasingSubsequence
{
    public static string Solve(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        var numbers = input
            .Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int n = numbers.Length;

        // dp[i] = length of increasing subsequence ending at i
        int[] dp = new int[n];

        // prev[i] = previous index in the sequence ending at i
        int[] prev = new int[n];

        // start[i] = starting index of the sequence ending at i
        int[] start = new int[n];

        for (int i = 0; i < n; i++)
        {
            dp[i] = 1;
            prev[i] = -1;
            start[i] = i;
        }

        // Build DP
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (numbers[j] < numbers[i])
                {
                    int newLen = dp[j] + 1;

                    if (newLen > dp[i])
                    {
                        dp[i] = newLen;
                        prev[i] = j;
                        start[i] = start[j];
                    }
                    else if (newLen == dp[i])
                    {
                        // If same length, prefer the one that starts earlier
                        if (start[j] < start[i])
                        {
                            prev[i] = j;
                            start[i] = start[j];
                        }
                    }
                }
            }
        }

        // Choose the best ending index:
        // 1) Longer length is better
        // 2) If same length, earlier start is better
        // 3) If same start, earlier end is better
        int bestEnd = 0;

        for (int i = 1; i < n; i++)
        {
            if (dp[i] > dp[bestEnd] ||
                (dp[i] == dp[bestEnd] &&
                 (start[i] < start[bestEnd] ||
                  (start[i] == start[bestEnd] && i < bestEnd))))
            {
                bestEnd = i;
            }
        }

        // Reconstruct the sequence
        var result = new List<int>();
        int current = bestEnd;

        while (current != -1)
        {
            result.Add(numbers[current]);
            current = prev[current];
        }

        result.Reverse();

        return string.Join(" ", result);
    }
}
