public class Barrel : IGameObject
{

    private char _symbol;
    private IMoveBehavior _moveBehavior;
    private ICollisionBehavior _collisionBehavior;
  
    private Position _position;
    

    public Barrel(char symbol, Position position,
     IMoveBehavior moveBehavior, ICollisionBehavior collisionBehavior)
    {
        _symbol = symbol;
        _position = position;
        _moveBehavior = moveBehavior;
        _collisionBehavior = collisionBehavior;
    }
    public void Update(Map map) => _position = _moveBehavior.Move(_position, map);
    public void OnCollide(Climber climber) => _collisionBehavior.Collide(climber);
    public void Draw(IRenderer renderer)
    {
        renderer.DrawSprite(_position, _symbol, _collisionBehavior.GetEffectColor());
    }
    public bool IsAt(Position position)
    {
        return _position == position; 
    }
    public bool IsOutOfBounds(Map map)
    {
        return map.IsOutOfBounds(_position);
    }


}