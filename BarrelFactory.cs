public class BarrelFactory : GameObjectFactory
{   
    private readonly char _symbol;
    private readonly Func<IMoveBehavior> _moveBehaviorFactory;
    private readonly Func<ICollisionBehavior> _collisionBehaviorFactory;
    public BarrelFactory(IReadOnlyList<Position> spawnLocations, char symbol, Func<IMoveBehavior> moveBehaviorFactory, Func<ICollisionBehavior> collisionBehaviorFactory) : base(spawnLocations)
    {
        _symbol = symbol;
        _moveBehaviorFactory = moveBehaviorFactory;
        _collisionBehaviorFactory = collisionBehaviorFactory;
    }
    public override IGameObject Create()
    {
        Position pos = SelectSpawn();

        return new Barrel(
            _symbol, 
            pos, 
            _moveBehaviorFactory(), 
            _collisionBehaviorFactory()
            
            );

    }
}