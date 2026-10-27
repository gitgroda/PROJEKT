

Console.Clear();
Console.CursorVisible = false;
List<MenuItem<int>> difficultyItems = new List<MenuItem<int>>
{
    new MenuItem<int>("Easy (10 HP)", 9),
    new MenuItem<int>("Normal (6 HP)", 6),
    new MenuItem<int>("Hard (3 HP)", 3)
};

List<MenuItem<IClimberPhysics>> playerPhysics = new List<MenuItem<IClimberPhysics>>
{
    new MenuItem<IClimberPhysics>("Earth gravity", new StandardPhysics()),
    new MenuItem<IClimberPhysics>("Moon gravity", new LowGravityPhysics()),
    new MenuItem<IClimberPhysics>("Sumo gravity", new HeavyPhysics()),
    new MenuItem<IClimberPhysics>("Flying", new FlyingPhysics()),
};

Menu<int> difficultyMenu = new Menu<int>("VÄLJ SVÅRIGHETSGRAD", difficultyItems);
Menu<IClimberPhysics> physicsMenu = new Menu<IClimberPhysics>("VÄLJ GRAVITY-MODE", playerPhysics);

int startingHp = difficultyMenu.Show();
IClimberPhysics physics = physicsMenu.Show();

Map map = new Map();
Climber climber = new Climber(startingHp, physics);

IRenderer render = new ConsoleRenderer();

List<Position> barrelSpawns = new List<Position>
{
    new Position(70, 4)
};

List<Position> potionSpawns = new List<Position>
{
    new Position(70, 24),
    new Position(10, 19),
    new Position(70, 14),
    new Position(10, 9),
};

List<Position> firetrapSpawns = new List<Position>
{
    new Position(65, 16),
    new Position(15, 11),
    new Position(65, 6),
    new Position(15, 1),    
};

//FALL #7 Program.cs
// VAD är det för koncept ni påstår att ni använder?
// Delegater och beroendeinjektion
// HUR använder ni konceptet?
// Delegatinstanser av typen Func<IMoveBehavior> och Func<ICollisionBehavior> skapas
// och injiceras via konstruktorn i MovableFactory och StaticFactory. Fabrikerna
// anropar delegaterna vid Create() för att skapa nya instanser.
// VARFÖR använder ni konceptet?
// För att förhindra shared mutable state mellan spelobjekt. Genom att skicka in
// skapandelogik via delegater genererar fabrikerna helt nya, oberoende instanser av
// beteendena för varje objekt, istället för att alla delar samma referens.

GameObjectFactory bouncyFactory = new MovableFactory(barrelSpawns, '@', () => new BouncingBehavior(), () => new NormalCollide());
GameObjectFactory poisonFactory = new MovableFactory(barrelSpawns, '@', () => new RollingBehavior(), () => new PoisonCollide());

GameObjectFactory potionFactory = new StaticFactory(potionSpawns, 'P', () => new HealCollide());
GameObjectFactory firetrapFactory = new StaticFactory(firetrapSpawns, 'F', () => new NormalCollide());

SpawnManager spawner = new SpawnManager(
    bouncyFactory, 
    poisonFactory, 
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

// FALL #8: Program.cs
// VAD är det för koncept ni påstår att ni använder?
// Delegater och beroendeinjektion
// HUR använder ni konceptet?
// Delegater av typen Action skapas och injiceras i MenuItem<Action> för huvudmenyn.
// Menyn exekverar den valda delegaten när användaren trycker Enter.
// VARFÖR använder ni konceptet?
// För att frikoppla menysystemet från vad valen faktiskt gör. Menyn behöver inte
// känna till spelet eller avslutningslogik, utan exekverar bara den injicerade
// delegaten. De två delegaterna skiljer sig fundamentalt i beteende: den ena startar
// spellopen (game.Run()) medan den andra terminerar applikationen (Environment.Exit(0)).

List<MenuItem<Action>> menuItems = new List<MenuItem<Action>>
{
    new MenuItem<Action>("Starta spelet", () => game.Run()),
    new MenuItem<Action>("Avsluta", () => Environment.Exit(0))
};

Menu<Action> mainMenu = new Menu<Action>("DONKEY KONG", menuItems);

Action selectedAction = mainMenu.Show();
selectedAction.Invoke();
