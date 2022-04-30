namespace Bruteforce;

public static class Sunday
{
    public static int SundayFunc(string text, string pattern)
    {
        int i, j, checker = 0;
        int[] A = new int[128];
        int count = 0;
        for(int a=0; a<128; a++)
            A[a] = pattern.Length+1;

        for(j=0; j<pattern.Length; j++)
            A[pattern[j]] = pattern.Length-j;

        for(i=0; i<text.Length-pattern.Length; i+=A[text[i+pattern.Length]])
        {
            j=0;
            while(j<pattern.Length && (text[i+j] == pattern[j]))
                j++;
            if (j == pattern.Length)
            {
                count++;
                j = 0;
            }

        }
        return count == 0 ? -1 : count;
    }
}