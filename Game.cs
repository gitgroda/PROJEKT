using System.Runtime.CompilerServices;
using System.Security;

public class Game (Map map, Climber climber, IRenderer render)
{
    private bool isRunning;
    private int _physicsFrameCounter = 0;


    public List<IGameObject> gameObjects = new List<IGameObject>();
    
    public void Run()
    {
        isRunning = true;
        while (isRunning)
        {
            HandleInput();
            foreach (var obj in gameObjects)
            {
            
                obj.Update(map);
                HandleCollision(obj);
            }
            climber.UpdatePoison();
            UpdatePhysics();
            render.Draw(map, climber, gameObjects);
            Thread.Sleep(16);
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
                TryMove(-2);
                break;
            case ConsoleKey.RightArrow or ConsoleKey.D:
                TryMove(2);
                break;
            case ConsoleKey.UpArrow or ConsoleKey.W:
                TryClimb(-2);
                break;
            case ConsoleKey.DownArrow or ConsoleKey.S:
                TryClimb(2);
                break;
            case ConsoleKey.Spacebar or ConsoleKey.F:
                TryJump();
                break;
            case ConsoleKey.Escape:
                isRunning = false;
                break;
        }
    }
    public void TryMove(int deltaX) //deltaX = +1 eller -1, deltaY = 0 då vi endast vill gå åt sidan
    {
        Position newPos = new Position(climber.Position.X + deltaX, climber.Position.Y);
    
        if(map.IsWalkable(newPos) && map.HasGroundBelow(newPos))
        {
           climber.MoveTo(newPos);
        }
        else if (!map.HasGroundBelow(newPos))
        {
            //climber.Fall();
        }
    }
    public void TryClimb(int deltaY) //deltaY = +1 eller -1, deltaX = 0 då vi endast vill klättra
    {
        Position newPos = new Position(climber.Position.X, climber.Position.Y + deltaY);

        if(map.IsLadder(newPos))
        {
            climber.MoveTo(newPos);
        }
    }
    public void TryJump()
    {
        if (!climber.isJumping && map.HasGroundBelow(climber.Position))
        {
            climber.StartJump(6);
        }
    }
//Ny metod som enbart mäter om ett objekt krockar med spelaren. Tänker att vi inte har planer på att implementera krockar mellan andra objekt? 
    private void HandleCollision(IGameObject obj)
    {
        if (obj.Position.X == climber.Position.X && obj.Position.Y == climber.Position.Y)
        {
            obj.onCollide(climber);
        }
        obj.onCollide(climber);
        gameObjects.Remove(obj);

    }
    private void UpdatePhysics()
    {
        _physicsFrameCounter++;
        if (_physicsFrameCounter < 2) return;
        _physicsFrameCounter = 0;

        if (map.IsLadder(climber.Position))
        {
            climber.CancelJump();
            return;
        }

        if (climber.isJumping)
        {
            if (map.IsWalkable(GetAbovePos()) && !map.IsLadder(GetAbovePos()))
            {
                climber.MoveTo(GetAbovePos());
                climber.DuringJump();
            }
            else
            {
                climber.CancelJump();
            }
            return;

        }
        if (!map.HasGroundBelow(climber.Position))      //om climber faller 
        {
            if (map.IsWalkable(GetBelowPos()))
            {
                climber.MoveTo(GetBelowPos()); 
            }
        }
    } 
    private Position GetBelowPos()
    {
        return new Position(climber.Position.X, climber.Position.Y + 1);
    }
    private Position GetAbovePos()
    {
        return new Position(climber.Position.X, climber.Position.Y - 1);
    }
}
