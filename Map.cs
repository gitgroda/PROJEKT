using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

public class Map
{
    public Grid grid { get; }
    public Dictionary<Position, IGameObject> entities = new();

    public Map(int width, int height)
    {
        grid = new Grid(width, height);
    }
    public int Width => grid.Width;
    public int Height => grid.Height;
    public IGameObject GetEntityAt(Position pos)
    {
        if(entities.TryGetValue(pos, out var gameObject))
        {
            return gameObject;
        } 
        return null;
    }
    public void Place(Position pos, IGameObject obj) =>  entities[pos] = obj;
    public void Remove(Position pos) => entities.Remove(pos);
  
    public void TryMoveEntity(Position from, Position to)
    {
        if(entities.TryGetValue(from, out var obj))
        {
            if(GetEntityAt(to) != null && entities[from] != null)
            {

            }
            entities[to] = obj;
        }
    }    





    public char GetTile(Position pos) => grid.GetTile(pos);
    public void SetTile(Position pos, char tile) => grid.SetTile(pos, tile);
    public bool OutOfBounds(Position pos) => pos.X < 0 || pos.X >= Width || pos.Y < 0 || pos.Y >= Height;
    public bool IsWalkable(Position pos) => !OutOfBounds(pos) && (grid.GetTile(pos) == 'x');
    public bool IsLadder(Position pos)
    {
        if (OutOfBounds(pos)) return false;

        return grid.GetTile(pos) == 'H' || grid.GetTile(new Position(pos.X, pos.Y + 1)) == 'H'; //uppdatera till symbol för stege
    }
    public bool HasGroundBelow(Position pos)
    {
        if (OutOfBounds(pos)) return false;

        return grid.GetTile(pos) == 'x' || grid.GetTile(pos) == 'H' ; //uppdatera till symbol för golv / plattform
    }
}