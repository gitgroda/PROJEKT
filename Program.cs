
Console.Clear();
Console.CursorVisible = false;

Map map = new Map();
Climber climber = new Climber(10);
IRenderer render = new ConsoleRenderer();
SpawnManager spawner = new SpawnManager();

Game game = new Game(
    map, 
    climber, 
    render, 
    spawner
);

game.Run();