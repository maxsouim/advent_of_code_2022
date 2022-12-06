using System.Text;

namespace Day04
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<(Assignment AssignmentA, Assignment AssignmentB)> elvesPairs = new List<(Assignment AssignmentA, Assignment AssignmentB)>();
            foreach (string line in File.ReadLines(@"input.txt"))
            {
                if(!string.IsNullOrWhiteSpace(line))
                {
                    string[] assignments = line.Split(',');

                    elvesPairs.Add((AssignmentA: ParseAssignment(assignments[0]), AssignmentB: ParseAssignment(assignments[1])));
                }
            }

            Console.WriteLine($"{elvesPairs.Count(x => x.AssignmentA.Contains(x.AssignmentB) || x.AssignmentB.Contains(x.AssignmentA))} pairs fully contain the other.");

            Console.WriteLine($"{elvesPairs.Count(x => x.AssignmentA.Overlap(x.AssignmentB))} pairs overlap.");
        }

        static Assignment ParseAssignment(string assignmentStr)
        {
            string[] boundsSplit = assignmentStr.Split('-');

            return new Assignment(){
                LowerBound = int.Parse(boundsSplit[0]),
                UpperBound = int.Parse(boundsSplit[1])
            };
        }
    }
}