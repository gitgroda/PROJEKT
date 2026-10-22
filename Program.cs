Console.Clear();
Console.CursorVisible = false;
Map map = new Map(80, 24);
Climber climber = new Climber(new Position(5, map.GetHeight() - 2), 5);
IRenderer render = new ConsoleRenderer();

IGameObjectFactory barrelFactory = new BarrelFactory('b', new BouncingBehavior(), new NormalCollide());
IGameObjectFactory barrelFactory2 = new BarrelFactory('R', new RollingBehavior(), new PoisonCollide());

IGameObjectFactory potionFactory = new PotionFactory('p', new Heal());

Game game = new Game(map, climber, render);


barrelFactory.Create(game);
potionFactory.Create(game);
barrelFactory2.Create(game);
game.Run();