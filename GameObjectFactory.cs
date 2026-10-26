// FALL #4:
// VAD är det för koncept ni påstår att ni använder?
// Factory Method Pattern
// HUR använder ni konceptet?
// Vi skapar factories som skapar våra GameObjects, så som barrels, potions och firetraps. Två subtyper Movable och Static. Genom Create() och SelectSpawn(),
// hanterar subtyperna skapandet och retur av nya objekt. Injiceras i SpawnManager från Program.cs
// VARFÖR använder ni konceptet?
// Frikopplar spawnmanager från detaljer om hur objekt skapas och placeras, endast när.
// Fabrikerna ansvarar för hur och var objekten skapas. Minskar coupling och gör det enkelt att 
// lägga till nya objekt
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