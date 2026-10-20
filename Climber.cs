using System;
using System.Diagnostics.CodeAnalysis;
public class Climber
{
    public Position Position {get; set;}
    public Health HP {get; set;}
    public char Symbol {get; } = '@';
    private PoisonEffect poisonStatus = new PoisonEffect();

    

    public Climber(Position position, Health hp)
    {
        Position = position;
        HP = hp;
    }
    public void MoveTo(int targetX, int targetY) 
    {
        Position = new Position(targetX, targetY);

    }
    public void ApplyPoison() => poisonStatus.Apply();
    public void UpdatePoison() => poisonStatus.Update(this.HP);
}