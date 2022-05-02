namespace Bruteforce;

public static class RabinKarp
{
    private static int prime = 101;
    //new func is much more optimized because it don't use Math.pow and string.substring and also don't have function calls
    public static int RabinCarpOptimized(string text, string pattern)
    {
        int p = 0;
        int t = 0;
        int h = 1;
        int count = 0;
     

        for (int i = 0; i < pattern.Length-1; i++)
            h = (h*256)%prime;
        
        for (int i = 0; i < pattern.Length; i++)
        {
            p = (256*p + pattern[i])%prime;
            t = (256*t + text[i])%prime;
        }

        for (int i = 0; i <= text.Length - pattern.Length; i++)
        {
            if ( p == t )
            {
                int j;
                for (j = 0; j < pattern.Length; j++)
                {
                    if (text[i+j] != pattern[j])
                        break;
                }

                if (j == pattern.Length)
                    count++;

            }

            if ( i < text.Length-pattern.Length )
            {
                t = (256*(t - text[i]*h) + text[i+pattern.Length])%prime;
     

                if (t < 0)
                    t = (t + prime);
            }
        }

        return count;
    }
    
    static int Hash(string text)
    {
        int hash = 0;

        for(int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            hash += c * (int) (Math.Pow(prime, text.Length - 1 - i));
        }

        return hash;
    }
    static int RollHash(int previousHash, string previousText, string currentText)
    {
        int firstCharHash = previousText[0] * (int) (Math.Pow(prime, previousText.Length - 1));
        int hash = (previousHash - firstCharHash) * prime + currentText[currentText.Length - 1];

        return hash;
    }
    public static int RabinKarpFunc(string text, string pattern)
    {
        var hashPattern = Hash(pattern);
        var hashText = Hash(text.Substring(0, pattern.Length));
        var prevText = text.Substring(0, pattern.Length);
        int count = 0;

        for (int i = 0; i < text.Length - pattern.Length; i++)
        {
            if (hashPattern == hashText)
            {
                if (text.Substring(i, pattern.Length) == pattern)
                {
                    count++;
                }
            }

            if (i + pattern.Length < text.Length)
            {
                hashText = RollHash(hashText, prevText, text.Substring(i + 1, pattern.Length));
                prevText = text.Substring(i + 1, pattern.Length);
            }
        }

        return count == 0 ? -1 : count;
    }
}