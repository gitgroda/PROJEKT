public class FiretrapFactory(
    char _symbol, 
    Func<ICollisionBehavior> createCollisionBehavior) : IGameObjectFactory
{

    public void Create(Game game)
    {
        game.AddGameObject(new Firetrap(_symbol, new Position(40, 20), createCollisionBehavior()));
    }
}