public class PotionFactory(char symbol,
      Func<ICollisionBehavior> createCollisionBehavior) : IGameObjectFactory
{
    public void Create(Game game)
    {
        game.AddGameObject(new Potion(symbol, new Position(73, 7), createCollisionBehavior()));

    }
}