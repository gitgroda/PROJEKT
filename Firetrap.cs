public class Firetrap : IGameObject
{
    private char _symbol;
    private Position _position;
    private ICollisionBehavior _collisionBehavior;
    public Firetrap(char symbol, Position position, ICollisionBehavior collisionBehavior)
    {
        _symbol = symbol;
        _position = position;
        _collisionBehavior = collisionBehavior;
    }
    public void Update(Map map)
    {
        
    }
    public void onCollide(Climber climber)
    {
        _collisionBehavior.Collide(climber);
    }

    public void Draw(IRenderer renderer)
    {
        renderer.DrawSprite(_position, _symbol, _collisionBehavior.GetEffectColor());
    }

    public bool IsAt(Position position)
    {
        return _position == position;
    }
}