using System.Text;

namespace Day03
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<(string compartmentA, string compartmentB, string all)> rucksacks = new List<(string compartmentA, string compartmentB, string all)>();
            foreach (string line in File.ReadLines(@"input.txt"))
            {
                if(!string.IsNullOrWhiteSpace(line))
                {
                    rucksacks.Add((compartmentA: line.Substring(0, line.Length / 2), compartmentB: line.Substring(line.Length / 2, line.Length / 2), all: line));
                }
            }

            // Part one
            int priorities = 0;
            foreach((string compartmentA, string compartmentB, string all) rucksack in rucksacks)
            {
                foreach(char item in rucksack.compartmentA)
                {
                    if(rucksack.compartmentB.Contains(item))
                    {
                        priorities += GetCharValue(item.ToString());
                        break;
                    }
                }
            }
            Console.WriteLine($"(Part one) The sum of priorities is: {priorities}.");

            // Part two
            priorities = 0;
            int counter = 0;
            foreach((string compartmentA, string compartmentB, string all) rucksack in rucksacks)
            {
                if(++counter % 3 == 0)
                {
                    string prevPrevElfRucksack = rucksacks[counter - 3].all;
                    string prevElfRucksack = rucksacks[counter - 2].all;
                    string currentElfRucksack = rucksacks[counter - 1].all;

                    foreach(char item in currentElfRucksack)
                    {
                        if(prevPrevElfRucksack.Contains(item) && prevElfRucksack.Contains(item))
                        {
                            priorities += GetCharValue(item.ToString());
                            break;
                        }
                    }
                }

            }
            Console.WriteLine($"(Part two) The sum of priorities is: {priorities}.");
        }

        static int GetCharValue(string c)
        {
            int value = Encoding.ASCII.GetBytes(c)[0];
            return value >= 97 ? value - 96 : value - 38;
        }
    }
}