public interface ICollisionBehavior
{
    ConsoleColor EffectColor {get;}
    void Collide(Climber climber);
    ConsoleColor EffectColor { get; }
}