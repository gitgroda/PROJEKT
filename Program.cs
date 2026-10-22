Console.Clear();
Console.CursorVisible = false;
Map map = new Map();

Climber climber = new Climber(5);
IRenderer render = new ConsoleRenderer();

IGameObjectFactory bouncyBarrel = new BarrelFactory('@', new BouncingBehavior(), new NormalCollide());
IGameObjectFactory poisonBarrel = new BarrelFactory('@', new RollingBehavior(), new PoisonCollide());

IGameObjectFactory potionFactory = new PotionFactory('p', new Heal());

Game game = new Game(map, climber, render);


bouncyBarrel.Create(game);
poisonBarrel.Create(game);
potionFactory.Create(game);

game.Run();