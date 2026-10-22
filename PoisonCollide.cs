using Microsoft.VisualBasic;

public class PoisonCollide : ICollisionBehavior
{
    public ConsoleColor GetEffectColor() => ConsoleColor.Green;
    public void Collide(Climber climber)
    {
        climber.ApplyPoison();
    }
}