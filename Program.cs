
Console.Clear();
Console.CursorVisible = false;

Map map = new Map();
Climber climber = new Climber(10);
IRenderer render = new ConsoleRenderer();
IGameObjectFactory bouncyFactory = new BarrelFactory('@',() => new BouncingBehavior(), () => new NormalCollide());
IGameObjectFactory poisonFactory = new BarrelFactory('@', () => new RollingBehavior(), () => new PoisonCollide());
IGameObjectFactory normalFactory = new BarrelFactory('@', () => new RollingBehavior(), () => new NormalCollide());
IGameObjectFactory potionFactory = new PotionFactory('P', () => new HealCollide());
IGameObjectFactory firetrapFactory = new FiretrapFactory('F', () => new NormalCollide());

SpawnManager spawner = new SpawnManager(
    bouncyFactory, 
    poisonFactory, 
    normalFactory, 
    potionFactory, 
    firetrapFactory
);

Game game = new Game(
    map, 
    climber, 
    render, 
    spawner
);

game.Run();