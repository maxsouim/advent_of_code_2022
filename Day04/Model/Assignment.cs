namespace Day04
{
    public class Assignment
    {
        public int LowerBound { get; init; }
        public int UpperBound { get; init; }

        public Assignment() { }

        public bool Contains(Assignment assignment)
        {
            return assignment.LowerBound >= this.LowerBound && assignment.UpperBound <= this.UpperBound;
        }

        public bool Overlap(Assignment assignment)
        {
            if (this.LowerBound == assignment.LowerBound
                || this.LowerBound == assignment.UpperBound
                || this.UpperBound == assignment.LowerBound
                || this.UpperBound == assignment.UpperBound)
            {
                return true;
            }
            else
            {
                return (assignment.LowerBound > this.LowerBound && assignment.LowerBound < this.UpperBound)
                    || (assignment.UpperBound > this.LowerBound && assignment.UpperBound < this.UpperBound)
                    || (this.LowerBound > assignment.LowerBound && this.LowerBound < assignment.UpperBound)
                    || (this.UpperBound > assignment.LowerBound && this.UpperBound < assignment.UpperBound);
            }
        }
    }
}