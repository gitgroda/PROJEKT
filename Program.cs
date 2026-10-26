
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
List<MenuItem<Action>> menuItems = new List<MenuItem<Action>>
{
    new MenuItem<Action>("Starta spelet", () => game.Run()),
    new MenuItem<Action>("Avsluta", () => Environment.Exit(0))
};

Menu<Action> mainMenu = new Menu<Action>("DONKEY KONG", menuItems);

// 3. Visa menyn och kör den Action som användaren valde!
Action selectedAction = mainMenu.Show();
selectedAction.Invoke();
