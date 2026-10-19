Console.Clear();

Map map = new Map(90, 30);
Renderer render = new Renderer();
Climber climber = new Climber(new Position(5, map.Height - 2), new Health(5));

Game game = new Game(map, climber, render);

game.Run();









