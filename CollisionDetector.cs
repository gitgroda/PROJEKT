public class CollisionDetector
   { 
    public bool CheckCollsion(IGameObject obj, Climber climber)
    {
        if (climber.IsCollidingWith(obj))
        {
            obj.OnCollide(climber);
            return true;
        }
        return false;
    }
    public bool CheckOutOfBounds(IGameObject obj, Map map) => obj.OutOfBounds(map);
    }