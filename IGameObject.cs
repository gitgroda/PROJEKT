public interface IGameObject
{
	public char Symbol { get; }
	void onCollide(Climber climber);
}
