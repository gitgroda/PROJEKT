public class Heal : ICollisionBehavior
{
    public ConsoleColor GetEffectColor() => ConsoleColor.Red;
    public void Collide(Climber climber)
    {
        climber.ApplyHeal();
    }
}