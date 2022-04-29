namespace Bruteforce;

public static class Sunday
{
    public static int SundayFuncOld(string text, string pattern)
    {
        int i, j, checker = 0;
        int[] A = new int[128];
        for(int a=0; a<128; a++)
            A[a] = pattern.Length+1;

        for(j=0; j<pattern.Length; j++)
            A[pattern[j]] = pattern.Length-j;

        for(i=0; i<text.Length-pattern.Length; i+=A[text[i+pattern.Length]])
        {
            j=0;
            while(j<pattern.Length && (text[i+j] == pattern[j]))
                j++;
            if(j==pattern.Length)
                return checker = i;
        }

        return checker = -1;
    }

    public static int SundayFunc(string text, string pattern)
    {
        var i = 0;
        while (i < text.Length)
        {
            var j = 0;
            while (j < pattern.Length && i + j < text.Length && text[i + j] == pattern[j])
            {
                j++;
            }

            if (j == pattern.Length)
            {
                return i;
            } 
            
            if (i + pattern.Length < text.Length)
            {
                for (j = pattern.Length - 1; j >= 0; j--)
                {
                    if (pattern[j] == text[i + pattern.Length])
                    {
                        break;
                    }
                }
            }

            i += pattern.Length - j;
        }

        return -1;
    }
}