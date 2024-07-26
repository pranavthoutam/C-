/*1.Take two strings as input and check whether the second string is a sub-string of the first or not. If yes, print 
the number of times occurred in S1 and 
print the index positions where the string appeared]

i/p : S1 = “abcdabcabd”

        S2 = “ab”

o/p: No.of times occurred = 3

        Index positions = 0 4 7*/
namespace StringOccurenceApp
{
    /// <summary>
    ///  The StringAnalyzer class contains methods to analyze and find occurrences of a substring within a given string.
    /// </summary>
    class StringAnalyzer
    {
        //
        public static void StringOccurence(string source, string pattern)
        {
            int occurences = 0;
            string positions = string.Empty;
            for (int i = 0; i <= source.Length - pattern.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (source[i + j] == pattern[j])
                        count++;
                    else break;
                }
                if (count == pattern.Length)
                {
                    occurences++;
                    positions += i;
                }
            }
            Console.WriteLine("No.of Occurences = {0}", occurences);
            foreach (var i in positions)
            {
                Console.Write("{0} ", i);
            }
        }
    }
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Input string");
            string inputString = Console.ReadLine();
            if (inputString == null) 
            Console.WriteLine("sub_string_Pattern");
            string pattern = Console.ReadLine();
            StringAnalyzer.StringOccurence(inputString, pattern);
        }
    }
}