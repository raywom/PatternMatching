namespace Bruteforce;

public static class RabinCarp
{
    private static int prime = 101;
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
    public static int RabinCarpFunc(string text, string pattern)
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