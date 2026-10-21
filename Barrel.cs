public class Barrel : IGameObject
{

    public char Symbol {get;}
    public IMoveBehavior MoveBehavior;
    public ICollisionBehavior CollisionBehavior;
    public Position Position { get; set; }
    public Barrel(char symbol, Position position, IMoveBehavior moveBehavior, ICollisionBehavior collisionBehavior)
    {
        Symbol = symbol;
        Position = position;
        MoveBehavior = moveBehavior;
        CollisionBehavior = collisionBehavior;
    }
    public void onCollide(Climber climber)
    {
        CollisionBehavior.Collide(climber);
    }
    public void Update(Map map)
    {
        MoveBehavior.Move(this, map);
    }
}