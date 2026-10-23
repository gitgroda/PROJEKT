public class SpawnManager()
{
    private int _ticks = 0;
    private IGameObjectFactory _bouncyFactory = new BarrelFactory('@', new BouncingBehavior(), new NormalCollide());
    private IGameObjectFactory _poisonFactory = new BarrelFactory('@', new RollingBehavior(), new PoisonCollide());
    private IGameObjectFactory _potionFactory = new PotionFactory('P', new HealCollide());
    private IGameObjectFactory _firetrapFactory = new FiretrapFactory('F', new NormalCollide());

    public void Update(Game game)
    {
        _ticks++;

        _firetrapFactory.Create(game);
        if (_ticks == 10)
        {
            _poisonFactory.Create(game);
        }
        else if (_ticks == 60)
        {
            _bouncyFactory.Create(game);
            _ticks = 0;
        }
    }

}