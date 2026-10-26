
Console.Clear();
Console.CursorVisible = false;
List<MenuItem<int>> difficultyItems = new List<MenuItem<int>>
{
    new MenuItem<int>("Lätt (10 HP)", 10),
    new MenuItem<int>("Normal (6 HP)", 6),
    new MenuItem<int>("Svår (3 HP)", 3)
};

Menu<int> difficultyMenu = new Menu<int>("VÄLJ SVÅRIGHETSGRAD", difficultyItems);
int startingHp = difficultyMenu.Show();
Map map = new Map();
Climber climber = new Climber(startingHp);
IRenderer render = new ConsoleRenderer();

List<Position> barrelSpawns = new List<Position>
{
    new Position(70, 4)
};

List<Position> potionSpawns = new List<Position>
{
    new Position(10, 9),
    new Position(70, 14),
    new Position(10, 19),
    new Position(70, 24),
};

List<Position> firetrapSpawns = new List<Position>
{
    new Position(15, 1),
    new Position(65, 6),
    new Position(15, 11),
    new Position(65, 16),
};

GameObjectFactory bouncyFactory = new BarrelFactory(barrelSpawns, '@', () => new BouncingBehavior(), () => new NormalCollide());
GameObjectFactory poisonFactory = new BarrelFactory(barrelSpawns, '@', () => new RollingBehavior(), () => new PoisonCollide());
GameObjectFactory normalFactory = new BarrelFactory(barrelSpawns, '@', () => new RollingBehavior(), () => new NormalCollide());
GameObjectFactory potionFactory = new PotionFactory(potionSpawns, 'P', () => new HealCollide());
GameObjectFactory firetrapFactory = new FiretrapFactory(firetrapSpawns, 'F', () => new NormalCollide());

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

game.AddGameObject(new Trophy('T', new Position(79, 4), new WinCollide()));

List<MenuItem<Action>> menuItems = new List<MenuItem<Action>>
{
    new MenuItem<Action>("Starta spelet", () => game.Run()),
    new MenuItem<Action>("Avsluta", () => Environment.Exit(0))
};

Menu<Action> mainMenu = new Menu<Action>("DONKEY KONG", menuItems);

// 3. Visa menyn och kör den Action som användaren valde!
Action selectedAction = mainMenu.Show();
selectedAction.Invoke();
