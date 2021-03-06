namespace Bruteforce;

public static class Bruteforce
{
    public static int BruteforceFunc(string text, string pattern)
    {
        var matchStartIndex = 0;
        var lastElementIndex = pattern.Length - 1;
        int count = 0;
        while (matchStartIndex < text.Length - lastElementIndex)
        {
            var stepOverTextIndex = 0;
            while (stepOverTextIndex <= lastElementIndex && text[matchStartIndex + stepOverTextIndex].Equals(pattern[stepOverTextIndex]))
            {
                stepOverTextIndex++;
            }

            if (stepOverTextIndex == pattern.Length)
            {
                count++;
            }

            matchStartIndex++;
        }

        return count == 0 ? -1 : count;
    }
}