using Raylib_cs;

public class RaylibRenderer : IRenderer
{
    private const int TileSize = 32; // Varje ruta i griddet blir 32x32 pixlar
    
    // Texturer / Sprites
    private readonly Texture2D _background;
    private readonly Texture2D _climberTexture;
    private readonly Texture2D _platformTexture;
    private readonly Texture2D _ladderTexture;

    public RaylibRenderer(int mapWidth, int mapHeight)
    {
        // 1. Öppna fönstret anpassat efter kartans storlek i pixlar
        Raylib.InitWindow(mapWidth * TileSize, mapHeight * TileSize, "Donkey Kong");
        Raylib.SetTargetFPS(60);

        // 2. Ladda in bildfilerna från en assets-mapp
        _background      = Raylib.LoadTexture("assets/background.png");
        _climberTexture  = Raylib.LoadTexture("assets/climber.png");
        _platformTexture = Raylib.LoadTexture("assets/platform.png");
        _ladderTexture   = Raylib.LoadTexture("assets/ladder.png");
    }

    public void Draw(Map map, Climber climber, List<IGameObject> gameObjects)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);

        // 1. Rita bakgrundsbilden först (täcker hela banan)
        Raylib.DrawTexture(_background, 0, 0, Color.White);

        // 2. Rita ut kartans rutor (samma loop som i ConsoleRenderer!)
        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                var tile = map.GetTile(new Position(x, y));
                int pixelX = x * TileSize;
                int pixelY = y * TileSize;

                // Mappa era tecken/typer till rätt bild
                if (tile == '=')
                {
                    Raylib.DrawTexture(_platformTexture, pixelX, pixelY, Color.White);
                }
                else if (tile == '#')
                {
                    Raylib.DrawTexture(_ladderTexture, pixelX, pixelY, Color.White);
                }
            }
        }

        // 3. Rita gubben ovanpå kartan på dess pixelposition
        int climberPixelX = climber.Position.X * TileSize;
        int climberPixelY = climber.Position.Y * TileSize;
        Raylib.DrawTexture(_climberTexture, climberPixelX, climberPixelY, Color.White);

        Raylib.EndDrawing();
    }
}