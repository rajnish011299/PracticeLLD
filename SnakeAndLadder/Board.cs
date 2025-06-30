class Board
{
    int boardSize;
    List<Snake> snakes;
    List<Ladder> ladders;
    Dice dice;
    Queue<Player> nextPlayer;

    public Board(int boardSize, List<Snake> snakes, List<Ladder> ladders, List<Player> players, Dice dice)
    {
        this.boardSize = boardSize;
        this.snakes = snakes;
        this.ladders = ladders;
        this.dice = dice;
        this.nextPlayer = new Queue<Player>(players);
    }

    public void Play()
    {
        bool gameEnd = false;
        while (!gameEnd)
        {
            Player player = nextPlayer.Dequeue();
            Console.WriteLine($"{player.name} is playing at position = {player.position}");

            int score = dice.RollDice();
            gameEnd = player.Move(score, snakes, ladders, boardSize);

            if (gameEnd)
            {
                Console.WriteLine($"{player.name} Won the Game!!!");
            }
            else // Keep playing
            {
                nextPlayer.Enqueue(player);
            }
        }
    }
}