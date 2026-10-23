public class FiretrapFactory(
    char _symbol, 
    ICollisionBehavior _collisionBehavior) : IGameObjectFactory
{

    public void Create(Game game)
    {
        game.AddGameObject(new Firetrap(_symbol, new Position(40, 20), _collisionBehavior));
    }
}