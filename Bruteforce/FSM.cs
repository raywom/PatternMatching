namespace Bruteforce;

public static class FSM
{
    public static int FSMFunc(string text, string pattern)
    {
        int count = 0;

        int[][] machine = new int[pattern.Length + 1][];
        for (int array1 = 0; array1 < pattern.Length + 1; array1++)
        {
            machine[array1] = new int[256];
        }

        for (int state = 0; state <= pattern.Length; ++state)
        for (int x = 0; x < 256; ++x)
            machine[state][x] = GetNextStateOfEngine(pattern, state, x);

        int checker = 0;
        foreach (var t in text)
        {
            checker = machine[checker][t];
            if (checker == pattern.Length)
                count++;
        }

        return count == 0 ? -1 : count;
    }
    
    static int GetNextStateOfEngine(string pattern, int state, int x)
    {
        if (state < pattern.Length && x == pattern[state])
            return state + 1;

        for (int j = state; j > 0; j--)
        {
            if (pattern[j - 1] == x)
            {
                int i;
                for (i = 0; i < j - 1; i++)
                    if (pattern[i] != pattern[state - j + 1 + i])
                        break;
                if (i == j - 1)
                    return j;
            }
        }

        return 0;
    }
}
