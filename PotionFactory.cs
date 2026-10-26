public class PotionFactory : GameObjectFactory
{   
    private readonly char _symbol;
    private readonly Func<ICollisionBehavior> _collisionBehaviorFactory;
    public PotionFactory (IReadOnlyList<Position> spawnLocations, char symbol, Func<ICollisionBehavior> collisionBehaviorFactory) : base(spawnLocations)
    {
        _symbol = symbol;
        _collisionBehaviorFactory = collisionBehaviorFactory;
    }
    public override IGameObject Create()
    {
        Position pos = SelectSpawn();

        return new Potion(
            _symbol, 
            pos, 
            _collisionBehaviorFactory()
            
            );

    }
}