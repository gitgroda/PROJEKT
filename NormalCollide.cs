public class NormalCollide : ICollisionBehavior
{
    public ConsoleColor GetEffectColor() => ConsoleColor.Red;
    public void Collide(Climber climber)
    {
        climber.TakeDamage();
    }
}