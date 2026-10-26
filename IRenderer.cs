public interface IRenderer
{
    void DrawMap(Map map); 
    void DrawSprite(Position position, char symbol, ConsoleColor color);
}