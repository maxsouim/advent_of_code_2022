namespace Day01
{
    public class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            List<Elf> elves = new List<Elf>();
            Elf elf = new Elf(++counter);

            foreach (string line in File.ReadLines(@"input.txt"))
            {
                if(!string.IsNullOrWhiteSpace(line))
                {
                    elf.Calories.Add(int.Parse(line));
                }
                else
                {
                    elves.Add(elf);
                    elf = new Elf(++counter);
                }
            }

            // add last elf
            elves.Add(elf);
            
            Console.WriteLine($"Elf {elves.MaxBy(x => x.CaloriesTotal)?.Order} has the most calories with {elves.MaxBy(x => x.CaloriesTotal)?.CaloriesTotal}.");

            Console.WriteLine($"Top 3 elves are carrying {elves.OrderByDescending(x => x.CaloriesTotal).Take(3).Sum(x => x.CaloriesTotal)} calories.");
        }
    }
}