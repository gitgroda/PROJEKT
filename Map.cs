using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

public class Map
{
    private Grid<char> _tiles;
    private Grid<bool> _solidGrid;
    private Grid<bool> _ladderGrid;

    
    public int Width { get; }
    public int Height { get; }
    private readonly char floorChar = '=';
    private readonly char ladderChar = 'H';
    public Map()
    {
        Width = 80;
        Height = 26;
        _tiles = new Grid<char>(Width, Height, ' ');
        _solidGrid = new Grid<bool>(Width, Height, false);
        _ladderGrid = new Grid<bool>(Width, Height, false);
        BuildLevel();
    }
    public char GetTile(Position pos) => _tiles.Get(pos, 'x');
    public void BuildFloor(int floor)
    {
        int floorY = Height - 1 - (floor * 5);
        for (int x = 0; x < Width; x++)
        {
            if (floor % 2 == 0 && floor != 0 && x < 4) continue;
            if (floor % 2 != 0 && x > Width - 5) continue;
            Position pos = new Position(x, floorY);
            _tiles.Set(pos, floorChar);
            _solidGrid.Set(pos, true);
        }
    }
    public void BuildLadder(int floor)
    {
        int floorY = Height - 1 - (floor * 5);
        int ladderX = (floor % 2 == 0) ? 5 : Width - 6;
        for (int y = floorY; y < floorY + 5; y++)
        {
            Position pos = new Position(ladderX, y);
            
            _tiles.Set(pos, ladderChar);
            _ladderGrid.Set(pos, true);
        }
    }
    public void BuildLevel()
    {
        for (int floor = 0; floor < 5; floor++)
        {
            BuildFloor(floor);
            if (floor > 0)
            {
                BuildLadder(floor);
            }
        }
    }
    public bool IsOutOfBounds(Position pos) => _tiles.IsOutOfBounds(pos);
    public bool IsWalkable(Position pos)
    {
        if (IsOutOfBounds(pos)) return false;
        return !_solidGrid.Get(pos, true);
    }

    public bool IsLadder(Position pos)
    {
        if (IsOutOfBounds(pos)) return false;
        return _ladderGrid.Get(pos, false);

    }
    public bool HasGroundBelow(Position pos)
    {
        Position below = new Position(pos.X, pos.Y + 1);

        if (IsOutOfBounds(below)) return false;
        
        return _solidGrid.Get(below, false) || _ladderGrid.Get(below, false);
    }
}