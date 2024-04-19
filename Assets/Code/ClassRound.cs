

public class Round
{
    public bool IsRuning;
    public Player winner;
    public Round()
    {
        IsRuning = true;
    }
    static void EndRound(Round round)
    {
        round.IsRuning = false;
    }
}