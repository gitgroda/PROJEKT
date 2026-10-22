using System.Runtime.Versioning;

public class Potion : IGameObject
{
	
	public char Symbol { get; }
	public Position Position { get; set; }
	public ICollisionBehavior CollisionBehavior;
	public ConsoleColor Color => CollisionBehavior.EffectColor;
	public Potion(char symbol, Position position,
      ICollisionBehavior collisionBehavior)
    {
        Symbol = symbol;
        Position = position;
        CollisionBehavior = collisionBehavior;
    }
	public void Update(Map map)
    {
        
    }
    public void onCollide(Climber climber)
    {
        CollisionBehavior.Collide(climber);
    }
	

}