public class FiretrapFactory(
    char _symbol, 
    Func<ICollisionBehavior> createCollisionBehavior) : IGameObjectFactory
{

    public void Create(Game game)
    {
        game.AddGameObject(new Firetrap(_symbol, new Position(40, 22), createCollisionBehavior()));  //Y kan vara 22 - (x * 5) //X kan vara mellan 20-60
    }
}