public class PotionFactory(char symbol,
      ICollisionBehavior collisionBehavior) : IGameObjectFactory
{
    public void Create(Game game)
    {
        game.AddGameObject(new Potion(symbol, new Position(73, 7), collisionBehavior));

    }
}