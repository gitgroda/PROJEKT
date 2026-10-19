public class Boss
{
    private Position position {get; }
    private char symbol;
    public Boss(Position position, char symbol)
    {
        this.symbol = symbol;
        this.position = position;
    }
}