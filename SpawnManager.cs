
public class SpawnManager
{
    private int _barrelTicks = 0;
    private int _trapTicks = 0;

    private GameObjectFactory _bouncyFactory;
    private GameObjectFactory _poisonFactory;
    private GameObjectFactory _normalFactory;
    private GameObjectFactory _potionFactory;
    private GameObjectFactory _firetrapFactory;

    // Injicera fabrikerna via konstruktorn för att uppfylla Factory-kravet!
    public SpawnManager(
        GameObjectFactory bouncyFactory,
        GameObjectFactory poisonFactory,
        GameObjectFactory normalFactory,
        GameObjectFactory potionFactory,
        GameObjectFactory firetrapFactory)
    {
        _bouncyFactory = bouncyFactory;
        _poisonFactory = poisonFactory;
        _normalFactory = normalFactory;
        _potionFactory = potionFactory;
        _firetrapFactory = firetrapFactory;
    }
    public void Update(Game game)
    {
        _barrelTicks++;
        _trapTicks++;

        if (_barrelTicks == 60)
        {
            game.AddGameObject(_poisonFactory.Create());
        }
        else if (_barrelTicks >= 120)
        {
             game.AddGameObject(_bouncyFactory.Create());
             _barrelTicks = 0;
        }
    
        if (_trapTicks == 120)
        {
             game.AddGameObject(_firetrapFactory.Create());
             game.AddGameObject(_potionFactory.Create());
        }
        else if (_trapTicks == 240)
        {
             game.AddGameObject(_firetrapFactory.Create());
             game.AddGameObject(_potionFactory.Create());
            _trapTicks = 0;
        }
    }

}