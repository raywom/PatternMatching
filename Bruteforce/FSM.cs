namespace Bruteforce;

public static class FSM
{
    public static int FSMFunc(string text, string pattern)
    {
        int i;
        var state = 0;
        var states = new int[pattern.Length];
        var symbols = new int[pattern.Length];

        for (i = 0; i < pattern.Length; i++)
        {
            states[i] = 0;
            symbols[i] = pattern[i];
        }

        while (i < text.Length)
        {
            if (text[i] == pattern[state])
            {
                i++;
                state++;
            }
            else
            {
                if (state > 0)
                {
                    state = states[state - 1];
                }
                else
                {
                    i++;
                }
            }
        }

        if (state == pattern.Length)
        {
            return i - pattern.Length;
        }

        return -1;
    }
}