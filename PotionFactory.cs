public class PotionFactory(char symbol, Position position,
      ICollisionBehavior collisionBehavior) : IGameObjectFactory
{
    public IGameObject Create()
    {
        Potion potion = new Potion(symbol, position, collisionBehavior);
        return potion;
    }
}