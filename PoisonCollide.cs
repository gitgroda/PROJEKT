using Microsoft.VisualBasic;

public class PoisonCollide : ICollisionBehavior
{
    public ConsoleColor EffectColor => ConsoleColor.Green;
    public void Collide(Climber climber)
    {
        climber.ApplyPoison();
    }
}