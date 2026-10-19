public class Renderer
{
    public void Draw(Grid grid, Climber climber)
    {
        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < grid.Height; y++)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                // Om spelaren står här, rita spelaren
                if (x == climber.position.X && y == climber.position.Y)
                {
                    Console.Write(climber.symbol);
                }
                else
                {
                    // Annars rita bakgrundsrutan
                    Console.Write(grid.GetTile(x, y));
                }
            }
            Console.WriteLine();
        }
    }
}