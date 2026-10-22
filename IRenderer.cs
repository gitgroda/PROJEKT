public interface IRenderer
{
    void DrawMap(Map map); // Vi bryter ut kartritningen
    void DrawSprite(Position position, char symbol, ConsoleColor color);
}