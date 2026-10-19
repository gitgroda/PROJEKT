
Grid grid = new Grid(80, 25);
Renderer render = new Renderer();

Console.SetWindowSize(80, 25);

Climber climber = new Climber(new Position(5, grid.Height - 3));
Console.Clear();

render.Draw(grid, climber);