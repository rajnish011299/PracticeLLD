class Snake
{
    public readonly int mouth;
    public readonly int tail;

    private Snake(int mouth, int tail)
    {
        this.mouth = mouth;
        this.tail = tail;
    }

    public static Snake Create(int mouth, int tail)
    {
        // Make sure mouth is greater than tail
        if (mouth < tail)
        {
            return new Snake(tail, mouth);
        }
        else
        {
            return new Snake(mouth, tail);
        }
    }

    public void Bite()
    {
        // Not implemented
    }
}