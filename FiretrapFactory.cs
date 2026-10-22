public class FiretrapFactory : IGameObjectFactory
{
    private char _symbol;
    private ICollisionBehavior _collisionBehavior;

    public FiretrapFactory(char symbol, ICollisionBehavior collisionBehavior)
    {
        _symbol = symbol;
        _collisionBehavior = collisionBehavior;
    }

    public void Create(Game game)
    {
        // Placerar fällan på en hårdkodad plats som exempel
        game.AddGameObject(new Firetrap(_symbol, new Position(40, 20), _collisionBehavior));
    }
}