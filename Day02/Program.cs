namespace Day02
{
    public class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            List<RockPaperScissorsRound> rounds = new List<RockPaperScissorsRound>();

            foreach (string line in File.ReadLines(@"input.txt"))
            {
                if(!string.IsNullOrWhiteSpace(line))
                {
                    string[] lineSplit = line.Split(' ');
                    rounds.Add(GameEngine2(++counter, lineSplit[0], lineSplit[1]));
                }
            }

            Console.WriteLine($"My total score: {rounds.Sum(x => x.Score)}.");
        }

        static RockPaperScissorsRound GameEngine1(int counter, string inputA, string inputB)
        {
            EHandShape opponentHandShape;
            EHandShape myHandShape;
            EOutcome outcome;

            switch (inputA.ToUpper())
            {
                case "A":
                    opponentHandShape = EHandShape.Rock;
                    break;
                case "B":
                    opponentHandShape = EHandShape.Paper;
                    break;
                case "C":
                    opponentHandShape = EHandShape.Scissors;
                    break;
                default:
                    throw new NotImplementedException(inputA);
            }

            switch (inputB.ToUpper())
            {
                case "X":
                    myHandShape = EHandShape.Rock;
                    break;
                case "Y":
                    myHandShape = EHandShape.Paper;
                    break;
                case "Z":
                    myHandShape = EHandShape.Scissors;
                    break;
                default:
                    throw new NotImplementedException(inputB);
            }

            if(opponentHandShape == myHandShape)
            {
                outcome = EOutcome.Draw;
            }
            else
            {
                switch(opponentHandShape)
                {
                    case EHandShape.Rock:
                        outcome = myHandShape == EHandShape.Paper ? EOutcome.Win : EOutcome.Loss;
                        break;

                    case EHandShape.Paper:
                        outcome = myHandShape == EHandShape.Scissors ? EOutcome.Win : EOutcome.Loss;
                        break;

                    case EHandShape.Scissors:
                        outcome = myHandShape == EHandShape.Rock ? EOutcome.Win : EOutcome.Loss;
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }

            return new RockPaperScissorsRound()
            {
                Order = counter,
                OpponentHandShape = opponentHandShape,
                MyHandShape = myHandShape,
                Outcome = outcome,
                Score = (int)myHandShape + (int)outcome
            };
        }

        static RockPaperScissorsRound GameEngine2(int counter, string inputA, string inputB)
        {
            EHandShape opponentHandShape;
            EHandShape myHandShape;
            EOutcome outcome;

            switch (inputA.ToUpper())
            {
                case "A":
                    opponentHandShape = EHandShape.Rock;
                    break;
                case "B":
                    opponentHandShape = EHandShape.Paper;
                    break;
                case "C":
                    opponentHandShape = EHandShape.Scissors;
                    break;
                default:
                    throw new NotImplementedException(inputA);
            }

            switch (inputB.ToUpper())
            {
                case "X":
                    outcome = EOutcome.Loss;
                    break;
                case "Y":
                    outcome = EOutcome.Draw;
                    break;
                case "Z":
                    outcome = EOutcome.Win;
                    break;
                default:
                    throw new NotImplementedException(inputB);
            }

            if(outcome == EOutcome.Draw)
            {
                myHandShape = opponentHandShape;
            }
            else
            {
                switch(opponentHandShape)
                {
                    case EHandShape.Rock:
                        myHandShape = outcome == EOutcome.Win ? EHandShape.Paper : EHandShape.Scissors;
                        break;

                    case EHandShape.Paper:
                        myHandShape = outcome == EOutcome.Win ? EHandShape.Scissors : EHandShape.Rock;
                        break;

                    case EHandShape.Scissors:
                        myHandShape = outcome == EOutcome.Win ? EHandShape.Rock : EHandShape.Paper;
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }

            return new RockPaperScissorsRound()
            {
                Order = counter,
                OpponentHandShape = opponentHandShape,
                MyHandShape = myHandShape,
                Outcome = outcome,
                Score = (int)myHandShape + (int)outcome
            };
        }
    }
}