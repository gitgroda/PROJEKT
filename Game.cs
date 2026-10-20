using System.Runtime.CompilerServices;
using System.Security;

public class Game (Map map, Climber climber, IRenderer render)
{
    private bool isRunning;
    public void Run()
    {
        isRunning = true;
        while (isRunning)
        {
            HandleInput();
            render.Draw(map, climber);
            Thread.Sleep(33);
        }
    }
    private void HandleInput()
    {
        if (!Console.KeyAvailable) return;

        ConsoleKey key = Console.ReadKey(intercept: true).Key;

        switch (key)
        {
            case ConsoleKey.LeftArrow or ConsoleKey.A:
                TryMove((-1));
                break;
            case ConsoleKey.RightArrow or ConsoleKey.D:
                TryMove(1);
                break;
            case ConsoleKey.UpArrow or ConsoleKey.W:
                TryClimb(-1);
                break;
            case ConsoleKey.DownArrow or ConsoleKey.S:
                TryClimb(1);
                break;
            case ConsoleKey.Escape:
                isRunning = false;
                break;
        }
    }
    public void TryMove(int deltaX) //deltaX = +1 eller -1, deltaY = 0 då vi endast vill gå åt sidan
    {
    
        if(map.IsWalkable(newPos) && map.HasGroundBelow(newPosBelow))
        {
            climber.MoveTo(climber.Position.X + deltaX, climber.Position.Y);
        }
    }
    public void TryClimb(int deltaY) //deltaY = +1 eller -1, deltaX = 0 då vi endast vill klättra
    {
        Position newPos = new Position(climber.Position.X, climber.Position.Y + deltaY);

        if(map.IsLadder(newPos))
        {
            climber.MoveTo(climber.Position.X, climber.Position.Y + deltaY);
        }
    }
    public void HandleCollision(IGameObject a, IGameObject b)   //Om vi kommer hit vet vi att en climber kolliderat med barrel. KOllar sedan vilken som är vilken och dela ut skada
    {
        if(a is Climber c && b is Barrel bar)
        {
             bar.OnCollide(c);
        }
        else if(a is Barrel _bar && b is Climber _c)
        {
             _bar.OnCollide(_c);
        }
        
    }
   


}