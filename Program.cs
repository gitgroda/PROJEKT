Console.Clear();
Console.CursorVisible = false;
Map map = new Map(80, 24);

Climber climber = new Climber(new Position(5, map.Height - 2), new Health(5));

IRenderer render = new ConsoleRenderer();

Game game = new Game(map, climber, render);
IMoveBehavior roll = new Rolling();
ICollisionBehavior poison = new Poison();

Barrel firstBarrel = new Barrel('O', new Position(79, 1), roll, poison);

game.gameObjects.Add(firstBarrel);
game.Run();









