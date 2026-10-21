public class Heal : ICollisionBehavior
{
    public ConsoleColor EffectColor => ConsoleColor.Red;
    public void Collide(Climber climber)
    {
        climber.ApplyHeal();
        //ska även ta bort från grid
    }
}