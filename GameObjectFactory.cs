public abstract class GameObjectFactory
{
    private readonly IReadOnlyList<Position> _spawnLocations;
    private int _locationIndex = 0;

    public GameObjectFactory(IReadOnlyList<Position> spawnLocations)
    {
        _spawnLocations = spawnLocations;
    }
    public Position SelectSpawn()
    {
        Position pos = _spawnLocations[_locationIndex];
        _locationIndex = (_locationIndex + 1) % _spawnLocations.Count;
        return pos;
    }
    public abstract IGameObject Create();
}