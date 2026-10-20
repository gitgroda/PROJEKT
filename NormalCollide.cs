public class NormalCollide : ICollisionBehavior
{
    public void Collide(Climber climber)
    {
        climber.HP.HP =- 1;
    }
}