using Microsoft.VisualBasic;

public class Poison : ICollisionBehavior
{
    public void Collide(Climber climber)
    {
        climber.ApplyPoison();
    }
}