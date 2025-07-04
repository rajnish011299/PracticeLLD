using System.ComponentModel;

class Ladder
{
    public readonly int head;
    public readonly int foot;

    private Ladder(int head, int foot)
    {
        this.head = head;
        this.foot = foot;
    }

    public static Ladder Create(int head, int foot)
    {
        if (head < foot)
        {
            return new Ladder(foot, head);
        }
        else
        {
            return new Ladder(head, foot);
        }
    }
}