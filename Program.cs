Console.Clear();

Map map = new Map(90, 30);
Climber climber = new Climber(new Position(5, map.Height - 2), new Health(5));
Renderer render = new Renderer(map, climber);

Game game = new Game(map, climber, render);

game.Run();









