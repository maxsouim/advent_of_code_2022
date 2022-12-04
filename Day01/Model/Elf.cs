namespace Day01
{
    public class Elf
    {
        public int Order { get; }
        public List<int> Calories { get; set; }
        public int CaloriesTotal => Calories.Sum();

        public Elf(int order)
        {
            Order = order;
            Calories = new List<int>();
        }
    }
}