// FALL #4:
// VAD är det för koncept ni påstår att ni använder?
// Delegater och beroendeinjektion
// HUR använder ni konceptet?
// Vi injicerar delegater (t.ex. Func<IMoveBehavior> och Func<ICollisionBehavior>) i fabrikererna (BarrelFactory, PotionFactory, FiretrapFactory) via SpawnManager.
// VARFÖR använder ni konceptet?
// För att förhindra shared state mellan spelobjekt. Genom att skicka in skapande-logik via delegater kan fabrikerna generera en helt ny, 
// oberoende instans av beteendena för varje specifikt objekt de skapar, istället för att alla objekt refererar till samma minnesreferens.
public class SpawnManager
{
    private int _barrelTicks = 0;
    private int _trapTicks = 0;

    private IGameObjectFactory _bouncyFactory;
    private IGameObjectFactory _poisonFactory;
    private IGameObjectFactory _normalFactory;
    private IGameObjectFactory _potionFactory;
    private IGameObjectFactory _firetrapFactory;

    // Injicera fabrikerna via konstruktorn för att uppfylla Factory-kravet!
    public SpawnManager(
        IGameObjectFactory bouncyFactory,
        IGameObjectFactory poisonFactory,
        IGameObjectFactory normalFactory,
        IGameObjectFactory potionFactory,
        IGameObjectFactory firetrapFactory)
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
            _poisonFactory.Create(game);
        }
        else if (_barrelTicks >= 120)
        {
            _bouncyFactory.Create(game);
            _barrelTicks = 0;
        }
        if (_trapTicks == 120)
        {
            _firetrapFactory.Create(game);
        }
        else if (_trapTicks == 240)
        {
            _firetrapFactory.Create(game);
            _trapTicks = 0;
        }
    }

}