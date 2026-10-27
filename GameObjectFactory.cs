// FALL #4: GameObjectFactory
// VAD är det för koncept ni påstår att ni använder?
// Factory Method Pattern
// HUR använder ni konceptet?
// Vi använder separata fabriker för att hantera instansieringen av spelets olika typer objekt.
// DVS t.ex. tunnor med olika beteenden, firetraps och potions. Vi använder då fabriker för att detta inte ska ske direkt i spellogiken.
// VARFÖR använder ni konceptet?
// För att minska kopplingen mellan spellogiken och de konkreta klasserna.
// Detta gör också det möjligt att instansiera nya objekt under runtime, t.ex. skapa nya tunnor som rullar.

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