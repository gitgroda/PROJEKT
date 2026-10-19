using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

public class Map
{
    private readonly Grid grid;

    public Map(int width, int height)
    {
        grid = new Grid(width, height);
    }
    public int Width => grid.Width;
    public int Height => grid.Height;
    public char GetTile(Position positon) => grid.GetTile(positon);
    public bool OutOfBounds(Position position)
    {
        if (position.X < 0 || position.X >= Width || position.Y < 0 || position.Y >= Height) return true;
        else return false;
    }
    public bool IsWalkable(Position position)
    {
        if(OutOfBounds(position)) return false;

        if (position.X < 0 || position.X >= Width || position.Y < 0 || position.Y >= Height) return false;
    
        else if (grid.GetTile(position) == 'x') return false;
        return true;
       
    }
    public bool IsLadder(Position position)
    {
        if (OutOfBounds(position)) return false;

        return grid.GetTile(position) == 'H';   //uppdatera till symbol för stege
    }
    public bool HasGroundBelow(Position position)
    {
        int belowY = position.Y + 1;

        if (OutOfBounds(position)) return false;

        if(belowY >= grid.Height) return true; //om spelare står på golvets border

        return grid.GetTile(position) == 'X'; //uppdatera till symbol för golv / plattform
        
    }

}