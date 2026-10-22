public interface IGameObject
{
	void Update(Map map);
    void onCollide(Climber climber);
    void Draw(IRenderer renderer);
	bool IsAt(Position position);
}
	