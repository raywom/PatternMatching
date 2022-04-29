namespace Bruteforce;

public static class RabinCarp
{
    static int Hash(string text){
        int hash = 0;
        for(int i=0; i<text.Length; i++){
            hash += text[i];
        }
        return hash;
    }
    public static int RabinCarpFunc(string text, string pattern)
    {
        var hashPattern = Hash(pattern);
        var hashText = Hash(text.Substring(0, pattern.Length));

        for (int i = 0; i < text.Length - pattern.Length; i++)
        {
            if (hashPattern == hashText)
            {
                if (text.Substring(i, pattern.Length) == pattern)
                {
                    return i;
                }
            }

            if (i + pattern.Length < text.Length)
            {
                hashText = Hash(text.Substring(i + 1, pattern.Length));
            }
        }

        return -1;
    }
}