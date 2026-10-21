public interface IGameObject
{
	public char Symbol { get; }
	Position Position { get; set; }
	void Update(Map map);
	void onCollide(Climber climber);
	ConsoleColor Color { get; }
}
