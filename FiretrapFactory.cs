public class FiretrapFactory : GameObjectFactory
{   
    private readonly char _symbol;
    private readonly Func<ICollisionBehavior> _collisionBehaviorFactory;
    public FiretrapFactory (IReadOnlyList<Position> spawnLocations, char symbol, Func<ICollisionBehavior> collisionBehaviorFactory) : base(spawnLocations)
    {
        _symbol = symbol;
        _collisionBehaviorFactory = collisionBehaviorFactory;
    }
    public override IGameObject Create()
    {
        Position pos = SelectSpawn();

        return new Firetrap(
            _symbol, 
            pos, 
            _collisionBehaviorFactory()
            
            );

    }
}