public class Barrel : IGameObject
{

    private char Symbol {get;}
    private IMoveBehavior MoveBehavior;
    private ICollisionBehavior CollisionBehavior;
  
    private Position Position { get; set; }
    

    public Barrel(char symbol, Position position,
     IMoveBehavior moveBehavior, ICollisionBehavior collisionBehavior)
    {
        Symbol = symbol;
        Position = position;
        MoveBehavior = moveBehavior;
        CollisionBehavior = collisionBehavior;
    }
    public void Update(Map map) => Position = MoveBehavior.Move(Position, map);
    public void onCollide(Climber climber) => CollisionBehavior.Collide(climber);
    public void Draw(IRenderer renderer)
    {
        renderer.DrawSprite(Position, Symbol, CollisionBehavior.GetEffectColor());
    }
    public bool IsAt(Position position)
{
    return Position == position; 
}
}