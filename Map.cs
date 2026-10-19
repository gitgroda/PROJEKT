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
       
    }
    public bool IsLadder()
    {
        if (Position)
    }poop

}