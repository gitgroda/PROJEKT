public class Renderer(Map map, Climber climber)
{
    public void Draw()
    {
        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                // if pos == player.pos, draw player
                if (x == climber.Position.X && y == climber.Position.Y)
                {
                    Console.Write(climber.Symbol);
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