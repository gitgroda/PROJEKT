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
    public void DrawText(Position position, string text)
    {
        ConsoleColor color = ConsoleColor.White;
        Console.SetCursorPosition(position.X, position.Y);
        Console.Write("         ");
        Console.SetCursorPosition(position.X, position.Y);
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }
   
}