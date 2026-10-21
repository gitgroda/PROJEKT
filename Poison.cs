using Microsoft.VisualBasic;

public class Poison : ICollisionBehavior
{
    public ConsoleColor EffectColor => ConsoleColor.Green;
    public void Collide(Climber climber)
    {
        climber.ApplyPoison();
    }
}