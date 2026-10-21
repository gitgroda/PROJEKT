public class Rolling : IMoveBehavior
{
    private int _direction = 1; // 1 = höger, -1 = vänster
    private bool _wasFalling = false;
    public void Move(IGameObject gameObject, Map map)
    {
        Position currentPos = gameObject.Position;
        Position nextPos;
        // Kontrollera om det finns mark under objektet
        if (!map.HasGroundBelow(currentPos))
        {
            //fall neråt om mark saknas
            nextPos = new Position(currentPos.X, currentPos.Y + 1);
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
            nextPos = new Position(currentPos.X + _direction, currentPos.Y);
        }
        //uppdaterar objektets position
        gameObject.Position = nextPos;

        
    }
}