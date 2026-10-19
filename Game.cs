using System.Security;

public class Game (Map map, Climber climber, Renderer render)
{
    private bool isRunning;
    public void Run()
    {
        isRunning = true;

        while (isRunning)
        {
            
        }
    }
    private void Render()
    {
        render.Draw(map, climber);
    }
    private void HandleMovement()
    {
        
    }
}