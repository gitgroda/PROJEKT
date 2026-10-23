// FALL #4:
// VAD är det för koncept ni påstår att ni använder?
// Delegater och beroendeinjektion
// HUR använder ni konceptet?
// Jag injicerar delegater (t.ex. Func<IMoveBehavior> och Func<ICollisionBehavior>) i mina fabriker (BarrelFactory, PotionFactory, FiretrapFactory) via SpawnManager.
// VARFÖR använder ni konceptet?
// För att förhindra delat tillstånd (shared state) mellan spelobjekt. Genom att skicka in skapande-logik via delegater kan fabrikerna generera en helt ny, oberoende instans av beteendena för varje specifikt objekt de skapar, istället för att alla objekt refererar till samma minnesadress.
public class SpawnManager()
{
    private int _barrelTicks = 0;
    private int _trapTicks = 0;

    private IGameObjectFactory _bouncyFactory = new BarrelFactory('@',() => new BouncingBehavior(), () => new NormalCollide());
    private IGameObjectFactory _poisonFactory = new BarrelFactory('@', () => new RollingBehavior(), () => new PoisonCollide());
    private IGameObjectFactory _normalFactory = new BarrelFactory('@', () => new RollingBehavior(), () => new NormalCollide());

    private IGameObjectFactory _potionFactory = new PotionFactory('P', () => new HealCollide());
    private IGameObjectFactory _firetrapFactory = new FiretrapFactory('F', () => new NormalCollide());

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