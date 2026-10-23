public class BarrelFactory(char symbol,
     Func<IMoveBehavior> createMoveBehavior, 
     Func<ICollisionBehavior> createCollisionBehavior) : IGameObjectFactory
{
    public void Create(Game game)
    {
        // Vi anropar delegaterna för att skapa NYA instanser för varje tunna
        game.AddGameObject(new Barrel(symbol, new Position(15, 1), createMoveBehavior(), createCollisionBehavior()));
    }
}