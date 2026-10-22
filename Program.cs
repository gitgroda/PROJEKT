Console.Clear();
Console.CursorVisible = false;
Map map = new Map(80, 24);
Climber climber = new Climber(new Position(5, map.Height - 2), 5);
IRenderer render = new ConsoleRenderer();

IGameObjectFactory barrelFactory = new BarrelFactory('b', new BouncingBehavior(), new NormalCollide());

IGameObjectFactory potionFactory = new PotionFactory('p', new Heal());

Game game = new Game(map, climber, render, barrelFactory, potionFactory);







//Barrel firstBarrel = new Barrel('O', new Position(79, 1), new Rolling(), new Poison());



barrelFactory.Create(game);
potionFactory.Create(game);
game.Run();