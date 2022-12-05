namespace Day02
{
    public class RockPaperScissorsRound
    {
        public int Order { get; init; }
        public EHandShape OpponentHandShape { get; init; }
        public EHandShape MyHandShape { get; init; }
        public EOutcome Outcome { get; init; }
        public int Score { get; init; }

        public RockPaperScissorsRound() { }
    }
}