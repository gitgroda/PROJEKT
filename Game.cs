using System.Runtime.CompilerServices;
using System.Security;

public class Game (Map map, Climber climber, IRenderer render, SpawnManager spawner)
{
    private bool _isRunning;
    private CollisionDetector _collisionDetector = new CollisionDetector();
    private List<IGameObject> _gameObjects = new List<IGameObject>();
    public void AddGameObject(IGameObject obj)
    {
        _gameObjects.Add(obj);
    }
    public void Run()
    {
        _isRunning = true;
        while (_isRunning)
        {
            HandleInput();
            for (int i = _gameObjects.Count - 1; i >= 0; i--)
            {
                var obj = _gameObjects[i];
                obj.Update(map);
                
                if (_collisionDetector.CheckCollsion(obj, climber) || obj.IsOutOfBounds(map))
                {
                    _gameObjects.RemoveAt(i);
                }
            }
            spawner.Update(this);
            climber.UpdatePhysics(map);
            climber.UpdateEffects();

            if(climber.IsDead())
            {
                Console.Clear();
                System.Console.WriteLine("You dead boi! Press any key to exit");
                _isRunning = false;
                Console.ReadLine();
                return;
            }

            if(climber.Win())
            {
                Console.Clear();
                System.Console.WriteLine("You won! Press any key to exit");
                _isRunning = false;
                Console.ReadLine();
                return;
            }

            render.DrawMap(map);
            render.DrawText(new Position(0, map.Height), "HP: " + climber.GetHP());
            for (int i = 0; i < _gameObjects.Count; i++)
            {
                _gameObjects[i].Draw(render);
            }
            climber.Draw(render);
            
        }
    }
    private void HandleInput()
    {
        if (!Console.KeyAvailable) return;
        ConsoleKey key = ConsoleKey.Escape; 
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
                _isRunning = false;
                break;
        }
    }
}
