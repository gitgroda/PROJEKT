using System.Formats.Tar;

public class Barrel : IThreat
{
    private Position position;
    private char symbol;
    private int damage;
    public Barrel(Position position)
    {
        this.position = position;
    }

    public Position GetPos()
    {
        return position;
    }

}