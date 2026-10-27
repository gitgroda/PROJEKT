public class RollingBehavior : IMoveBehavior
{
    private int _direction = -1; 
    private bool _wasFalling = false;
    public Position Move(Position currentPosition, Map map)
    {
        Position nextPos;
        if (!map.HasGroundBelow(currentPosition))
        {
            nextPos = new Position(currentPosition.X, currentPosition.Y + 1);
            _wasFalling = true;

        }
        else
        {
            if (_wasFalling)
            {
                _direction *= -1; 
                _wasFalling = false;
            }
            nextPos = new Position(currentPosition.X + _direction, currentPosition.Y);
        }
       return nextPos;
    }

}