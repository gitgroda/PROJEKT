public class CollisionDetector
   { 
    public bool CheckCollsion(IGameObject obj, Climber climber)
    {
        if (climber.IsCollidingWith(obj))
        {
            obj.onCollide(climber);
            return true;
        }
        return false;
    }
    
   }
    
    
    
    
   /*private void HandleCollision(IGameObject obj)
    {
        if (obj.Position.X == climber.Position.X && obj.Position.Y == climber.Position.Y)
        {
            obj.onCollide(climber);
            gameObjects.Remove(obj);
        }
    }*/