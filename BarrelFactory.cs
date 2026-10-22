public class BarrelFactory(char symbol,
     IMoveBehavior moveBehavior, ICollisionBehavior collisionBehavior) : IGameObjectFactory
{
   
    public void Create(Game game)
    {
        game.AddGameObject(new Barrel(symbol, new Position(79, 1), moveBehavior, collisionBehavior));
    }
}
