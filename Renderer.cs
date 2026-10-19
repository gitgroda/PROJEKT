public class Renderer
{
    public void Draw(Map map, Climber climber)
    {
        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                // if pos == player.pos, draw player
                if (x == climber.position.X && y == climber.position.Y)
                {
                    Console.Write(climber.symbol);
                }
                else
                {
                    // else draw background tile
                    Console.Write(map.GetTile(new Position(x, y)));
                }
            }
            Console.WriteLine();
        }
    }
}