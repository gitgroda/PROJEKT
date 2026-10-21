public class NormalCollide : ICollisionBehavior
{
    public ConsoleColor EffectColor => ConsoleColor.Red;
    public void Collide(Climber climber)
    {
        climber.HP.HP =- 1;
    }
}