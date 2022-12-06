namespace Day05
{
    public class Program
    {
        static void Main(string[] args)
        {
            // yes, hardcoded stacks
            Dictionary<int, Stack<char>> stacks = new Dictionary<int, Stack<char>>()
            {
                { 1, new Stack<char>(new [] {'Q','S','W','C','Z','V','F','T'}) },
                { 2, new Stack<char>(new [] {'Q','R','B'}) },
                { 3, new Stack<char>(new [] {'B','Z','T','Q','P','M','S'}) },
                { 4, new Stack<char>(new [] {'D','V','F','R','Q','H'}) },
                { 5, new Stack<char>(new [] {'J','G','L','D','B','S','T','P'}) },
                { 6, new Stack<char>(new [] {'W','R','T','Z'}) },
                { 7, new Stack<char>(new [] {'H','Q','M','N','S','F','R','J'}) },
                { 8, new Stack<char>(new [] {'R','N','F','H','W'}) },
                { 9, new Stack<char>(new [] {'J','Z','T','Q','P','R','B'}) },
            };

            foreach (string line in File.ReadLines(@"input.txt"))
            {
                if(!string.IsNullOrWhiteSpace(line))
                {
                    string[] intructions = line.Split(' ');
                    int qty = int.Parse(intructions[1]);
                    int srcStack = int.Parse(intructions[3]);
                    int destStack = int.Parse(intructions[5]);

                    // CrateMover 9000
                    // for(int i = 0; i < qty; i++)
                    // {
                    //     stacks[destStack].Push(stacks[srcStack].Pop());
                    // }

                    // CrateMover 9001
                    Stack<char> transitionStack = new Stack<char>();
                    for(int i = 0; i < qty; i++)
                    {
                        transitionStack.Push(stacks[srcStack].Pop());
                    }
                    for(int i = 0; i < qty; i++)
                    {
                        stacks[destStack].Push(transitionStack.Pop());
                    }
                }
            }

            foreach (var stack in stacks.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{stack.Key}: {stack.Value.Peek()}");
            }
        }
    }
}