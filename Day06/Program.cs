namespace Day06
{
    public class Program
    {
        static void Main(string[] args)
        {
            int sumChar = 0;
            const int SEQ_LENGTH = 14;

            foreach (string line in File.ReadLines(@"input.txt"))
            {
                if(!string.IsNullOrWhiteSpace(line))
                {
                    for(int i = (SEQ_LENGTH - 1); i < line.Length; i++)
                    {
                        if(!HasDuplicates(line.Substring(i - (SEQ_LENGTH - 1), SEQ_LENGTH)))
                        {
                            sumChar += (i + 1);
                            break;
                        }
                    }
                }
            }

            Console.WriteLine($"{sumChar} characters need to be processed.");
        }

        static bool HasDuplicates(string text)
        {
            foreach(char c in text)
            {
                if(text.Count(x => c == x) > 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}