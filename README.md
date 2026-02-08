Problem

The task is to write a function that takes a single string input containing integers separated by whitespace and returns the Longest Increasing Subsequence (LIS) from that sequence.




#Solution


The input string is parsed into an array of integers.

I used a dynamic programming approach:

dp[i] stores the length of the increasing subsequence ending at index i.

prev[i] stores the previous index to help reconstruct the sequence.

start[i] stores the starting index of the sequence ending at i to handle the “earliest sequence” rule.

While building the solution:

If a longer sequence is found, it replaces the current one.

If two sequences have the same length, the one that starts earlier in the original input is preferred.

Finally, the chosen sequence is reconstructed using the prev array and returned as a space-separated string
