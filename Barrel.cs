public class Barrel : IGameObject
{
    public int direction {get; set;} //1 = höger -1 = vänster
    public char Symbol {get;}
    public IMoveBehavior MoveBehavior;
    public ICollisionBehavior CollisionBehavior;
    public Barrel(char symbol, IMoveBehavior moveBehavior)
    {
        Symbol = symbol;
        MoveBehavior = moveBehavior;
    }
    public void onCollide(Climber climber)
    {
        CollisionBehavior.Collide(climber);
    }
}