public class BouncingBehavior : IMoveBehavior
{
    private int direction = 1; // 1 = höger, -1 = vänster
    private int bounceTicksLeft = 0;
    private int maxBounceHeight = 1;
    public void Move(IGameObject gameObject, Map map)
    {
        int x = gameObject.Position.X, y = gameObject.Position.Y;
        if (!map.IsWalkable(new Position(x + direction, y)))
        direction *= -1;
        x += direction;
        if (bounceTicksLeft > 0 && map.IsWalkable(new Position(x, y - 1)))
        {
            y--; 
            bounceTicksLeft--;
        }
        else
        {
            bounceTicksLeft = 0; 
            if (!map.HasGroundBelow(new Position(x, y))) y++; 
            else bounceTicksLeft = maxBounceHeight; 
        }

        gameObject.Position = new Position(x, y);
        Thread.Sleep(16);
    }
    
}