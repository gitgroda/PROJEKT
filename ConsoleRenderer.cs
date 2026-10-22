public class ConsoleRenderer : IRenderer
{
    public void DrawMap(Map map)
    {
        Console.SetCursorPosition(0, 0);
        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                Console.Write(map.GetTile(new Position(x, y)));
            }
            Console.WriteLine();
        }
    }
    public void DrawSprite(Position position, char symbol, ConsoleColor color)
    {
        Console.SetCursorPosition(position.X, position.Y);
        Console.ForegroundColor = color;
        Console.Write(symbol);
        Console.ResetColor();
    }
}