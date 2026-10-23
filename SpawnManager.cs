public class SpawnManager()
{
    private int _barrelTicks = 0;
    private int _trapTicks = 0;

    private IGameObjectFactory _bouncyFactory = new BarrelFactory('@', new BouncingBehavior(), new NormalCollide());
    private IGameObjectFactory _poisonFactory = new BarrelFactory('@', new RollingBehavior(), new PoisonCollide());
    private IGameObjectFactory _normalFactory = new BarrelFactory('@', new RollingBehavior(), new NormalCollide());

    private IGameObjectFactory _potionFactory = new PotionFactory('P', new HealCollide());
    private IGameObjectFactory _firetrapFactory = new FiretrapFactory('F', new NormalCollide());

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