using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

public class Map
{
    private Grid grid;
    

    public Map(int width, int height)
    {
        grid = new Grid(width, height);
    }
    public int GetWidth() => grid.GetWidth();
    public int GetHeight() => grid.GetHeight();

    public char GetTile(Position pos) => grid.GetTile(pos);
    public void SetTile(Position pos, char tile) => grid.SetTile(pos, tile);
    public bool OutOfBounds(Position pos) => pos.X < 0 || pos.X >= GetWidth() || pos.Y < 0 || pos.Y >= GetHeight();
    public bool IsWalkable(Position pos) => !OutOfBounds(pos) && (grid.GetTile(pos) != 'x');
    public bool IsLadder(Position pos)
    {
        if (OutOfBounds(pos)) return false;

        return grid.GetTile(pos) == 'H' || grid.GetTile(new Position(pos.X, pos.Y + 1)) == 'H'; //uppdatera till symbol för stege
    }
    public bool HasGroundBelow(Position pos)
    {
        Position belowPos = new Position(pos.X, pos.Y + 1); //kollar positionen med Y + 1

        if (OutOfBounds(belowPos)) return false;

        return grid.GetTile(belowPos) == 'x' || grid.GetTile(belowPos) == 'H' ; //symbol för golv / plattform och stege
    }
}