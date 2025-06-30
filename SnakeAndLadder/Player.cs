class Player
{
    public string name;
    public int position;

    public Player(string name)
    {
        this.name = name;
        this.position = 0;
    }

    /// <summary>
    /// returns true if Player wins
    /// </summary>
    /// <param name="steps"></param>
    /// <returns></returns>
    public bool Move(int steps, IEnumerable<Snake> snakes, IEnumerable<Ladder> ladders, int topPosition)
    {
        if (position + steps > topPosition)
        {
            return false; // need to roll exact 100
        }
        else if (position + steps == topPosition)
        {
            position = topPosition;
            return true;
        }
        else
        {
            // Check for snakes or ladder in new position
            int newPostiton = position + steps;
            bool hasSnake = snakes.Any(o => o.mouth == newPostiton);
            bool hasLadder = ladders.Any(o => o.foot == newPostiton);
            if (hasSnake)
            {
                Snake snake = snakes.Where(o => o.mouth == newPostiton).First();
                newPostiton = snake.tail;
            }
            else if (hasLadder)
            {
                Ladder ladder = ladders.Where(o => o.foot == newPostiton).First();
                newPostiton = ladder.head;
            }
            position = newPostiton;
            return false;
        }
    }
}