public class ConsoleRenderer : IRenderer
{
    public void Draw(Map map, Climber climber, List<IGameObject> gameObjects) //uppdaterad konstruktor med gameObjects
    {
        // 1. Rita ut kartan
        Console.SetCursorPosition(0, 0);
        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
                {
                    Console.Write(map.GetTile(new Position(x, y)));
                }
                Console.WriteLine();
            }
            //rita ut alla objekt i spelet
            foreach (var obj in gameObjects)
            {
                if ( obj.Position.X>= 0 && obj.Position.X < map.Width && obj.Position.Y >= 0 && obj.Position.Y < map.Height)
                {
                    Console.SetCursorPosition(obj.Position.X, obj.Position.Y);
                    Console.ForegroundColor = obj.Color;
                    Console.Write(obj.Symbol);
                    Console.ResetColor();
                }
            }
        // 3. Rita ut spelaren allra överst
        Console.SetCursorPosition(climber.Position.X, climber.Position.Y);
        Console.Write(climber.Symbol);
        }
    }
    
