public class BarrelFactory(char symbol, Position position,
     IMoveBehavior moveBehavior, ICollisionBehavior collisionBehavior) : IGameObjectFactory
{

    public IGameObject Create()
    {
        
        Barrel barrel = new Barrel(symbol, position, moveBehavior, collisionBehavior);
        return barrel;
    }
}
