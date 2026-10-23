public class RollingBehavior : IMoveBehavior
{
    private int _direction = -1; // 1 = höger, -1 = vänster
    private bool _wasFalling = false;
    public Position Move(Position currentPosition, Map map)
    {
        Position nextPos;
        // Kontrollera om det finns mark under objektet
        if (!map.HasGroundBelow(currentPosition))
        {
            //fall neråt om mark saknas
            nextPos = new Position(currentPosition.X, currentPosition.Y + 1);
            _wasFalling = true;

        }
        else
        {
            // Om objektet har fallit, byt riktning
            if (_wasFalling)
            {
                _direction *= -1; // Byt riktning efter att ha fallit
                _wasFalling = false;
            }
            //fortsätt rulla med nya riktningen
            nextPos = new Position(currentPosition.X + _direction, currentPosition.Y);
        }
        //uppdaterar objektets position
       return nextPos;
    }

}