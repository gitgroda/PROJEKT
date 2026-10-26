public interface IGameObject
{
	void Update(Map map);
    void OnCollide(Climber climber);
    void Draw(IRenderer renderer);
	bool IsAt(Position position);

}
