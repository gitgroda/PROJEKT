using System.Runtime.CompilerServices;
using System.Security;

public class Game (Map map, Climber climber, IRenderer render, IGameObjectFactory barrelFactory, IGameObjectFactory potionFactory)
{
    private bool isRunning;


    public List<IGameObject> gameObjects = new List<IGameObject>();
    
    public void Run()
    {
        isRunning = true;
        while (isRunning)
        {
            HandleInput();
            for (int i = gameObjects.Count - 1; i >= 0; i--)
            {
                var obj = gameObjects[i];
                obj.Update(map);
                HandleCollision(gameObjects[i]);
            }
            
            climber.UpdatePhysics(map);
            render.Draw(map, climber, gameObjects);

        }
    }
    private void HandleInput()
    {
        if (!Console.KeyAvailable) return;

        ConsoleKey key = ConsoleKey.Escape; // sätter en start key som inte gör något

    // När man håller in en tangent buffras en kö med tangenttryckningar. Detta sättet sparar enbart den senaste tryckningen så att climbern inte fortsätter röra sig när man släpper tangenten.
    while (Console.KeyAvailable)
    {
        key = Console.ReadKey(intercept: true).Key;
    }

        switch (key)
        {
            case ConsoleKey.LeftArrow or ConsoleKey.A:
                climber.TryMove(-1, map);
                break;
            case ConsoleKey.RightArrow or ConsoleKey.D:
                climber.TryMove(1, map);
                break;
            case ConsoleKey.UpArrow or ConsoleKey.W:
                climber.TryClimb(-1, map);
                break;
            case ConsoleKey.DownArrow or ConsoleKey.S:
                climber.TryClimb(1, map);
                break;
            case ConsoleKey.Spacebar or ConsoleKey.F:
                climber.TryJump(map);
                break;
            case ConsoleKey.Escape:
                isRunning = false;
                break;
        }
    }
    private void HandleCollision(IGameObject obj)
    {
        if (obj.Position.X == climber.Position.X && obj.Position.Y == climber.Position.Y)
        {
            obj.onCollide(climber);
            gameObjects.Remove(obj);
        }
    }
}
