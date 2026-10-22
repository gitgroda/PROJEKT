using System.Runtime.Versioning;

public class Potion : IGameObject
{
	
	private char Symbol;
	private Position Position;
	private ICollisionBehavior CollisionBehavior;
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
	
    public void Draw(IRenderer renderer)
    {
        renderer.DrawSprite(Position, Symbol, CollisionBehavior.GetEffectColor());
    }
    public bool IsAt(Position position)
    {
        return Position == position; 
    }

}