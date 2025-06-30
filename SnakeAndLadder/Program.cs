public class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        int numberOfSnakes = 5;
        int numberOfLadders = 5;
        int numberOfDice = 1;
        int numberOfPlayers = 2;
        int boardSize = 100;

        List<Snake> snakes = new List<Snake>();
        List<Ladder> ladders = new List<Ladder>();
        List<Player> players = new List<Player>();
        Dice dice = new Dice(numberOfDice);

        // Create snakes
        for (int i = 0; i < numberOfSnakes; i++)
        {
            snakes.Add(Snake.Create(random.Next(boardSize), random.Next(boardSize)));
        }

        // Create Ladders
        for (int i = 0; i < numberOfLadders; i++)
        {
            ladders.Add(Ladder.Create(random.Next(boardSize), random.Next(boardSize)));
        }

        // Create Players
        for (int i = 1; i <= numberOfPlayers; i++)
        {
            players.Add(new Player($"Player{i}"));
        }

        Board board = new Board(boardSize, snakes, ladders, players, dice);
        board.Play();
        Console.ReadKey();
    }
}