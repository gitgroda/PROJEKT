public class Climber
{
    public Health HP {get; set;}
    public char Symbol {get; } = '@';
    public Position Position;

    public Climber(Position position, Health hp)
    {
       Position = position;
       HP = hp;
    }
    public void MoveTo(int targetX, int targetY) 
    {
        Position = new Position(targetX, targetY);

    }
}