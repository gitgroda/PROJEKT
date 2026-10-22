public class Barrel : IGameObject
{

    private char Symbol {get;}
    private IMoveBehavior MoveBehavior;
    private ICollisionBehavior CollisionBehavior;
    private ConsoleColor Color => CollisionBehavior.EffectColor;
    private Position Position { get; set; }
    

    public Barrel(char symbol, Position position,
     IMoveBehavior moveBehavior, ICollisionBehavior collisionBehavior)
    {
        Symbol = symbol;
        Position = position;
        MoveBehavior = moveBehavior;
        CollisionBehavior = collisionBehavior;
    }
    public void Update(Map map) => MoveBehavior.Move(this, map);
    public void onCollide(Climber climber) => CollisionBehavior.Collide(climber);
    public void Draw(IRenderer renderer)
    {
        renderer.DrawSprite(Position, Symbol, CollisionBehavior.EffectColor);
    }
    public bool IsAt(Position position)
{
    return Position == position; 
}
}