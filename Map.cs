using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

public class Map
{
    private Grid _grid;
    public int Width { get; }
    public int Height { get; }
    public Map()
    {
        Width = 80;
        Height = 24;
        _grid = new Grid(Width, Height);
        _grid.Buildlevel();
    }
   
    public char GetTile(Position pos) => _grid.GetTile(pos);
    public void SetTile(Position pos, char tile) => _grid.SetTile(pos, tile);
    public bool OutOfBounds(Position pos) => pos.X < 0 || pos.X >= Width || pos.Y < 0 || pos.Y >= Height;
    public bool IsWalkable(Position pos) => !OutOfBounds(pos) && (_grid.GetTile(pos) != 'x');
    public bool IsLadder(Position pos)
    {
        if (OutOfBounds(pos)) return false;

        return _grid.GetTile(pos) == 'H' || _grid.GetTile(new Position(pos.X, pos.Y + 1)) == 'H'; 
    }
    public bool HasGroundBelow(Position pos)
    {
        Position _belowPos = new Position(pos.X, pos.Y + 1); //kollar positionen med Y + 1

        if (OutOfBounds(_belowPos)) return false;

        return _grid.GetTile(_belowPos) == 'x' || _grid.GetTile(_belowPos) == 'H' ; 
    }
}