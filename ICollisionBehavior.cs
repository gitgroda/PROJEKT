public interface ICollisionBehavior
{
    void Collide(Climber climber);
    ConsoleColor EffectColor { get; }
}