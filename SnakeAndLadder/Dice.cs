class Dice
{
    int diceCount = 1;
    Random random = new Random();

    public Dice(int diceCount = 1)
    {
        this.diceCount = diceCount;
    }

    public int RollDice()
    {
        // return a random number between 1 and 6
        int roll = 0;
        for (int i = 0; i < diceCount; i++)
        {
            roll += random.Next(1, 7);
        }
        return roll;
    }
}