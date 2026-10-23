public class BouncingBehavior : IMoveBehavior
{
    private int _direction = -1; // 1 = höger, -1 = vänster
    private int _bounceTicksLeft = 0;
    private int _maxBounceHeight = 1;
    public Position Move(Position currentPosition, Map map)
    {
        int x = currentPosition.X, y = currentPosition.Y;

        if (!map.IsWalkable(new Position(x + _direction, y)))
        _direction *= -1;
        x += _direction;
        if (_bounceTicksLeft > 0 && map.IsWalkable(new Position(x, y - 1)))
        {
            y--; 
            _bounceTicksLeft--;
        }
        else
        {
            _bounceTicksLeft = 0; 
            if (!map.HasGroundBelow(new Position(x, y))) y++; 
            else _bounceTicksLeft = _maxBounceHeight; 
        }
        Thread.Sleep(16);
        return new Position(x, y);
    }
    
}