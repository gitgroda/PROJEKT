using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

public class Map
{
    public Grid grid { get; }

    public Map(int width, int height)
    {
        grid = new Grid(width, height);
        Buildlevel();
    }

    private void Buildlevel() //göra randomised build level istället för att leveln alltid ser likadan ut? 
    {
        int width = grid.Width;
        int height = grid.Height;

        for (int floor = 0; floor < 5; floor++)
        {
            int floorY = height - (floor * 5); //Sätter varje våning 5 rader över den förra, golvet börjar på height - 2 eller height?
            for(int x = 0; x < width; x++)
           {
                // Lämnar luckor för tunnorna att falla ner
                if (floor % 2 == 0 && floor != 0 && x < 4) continue;
                if (floor % 2 != 0 && x > width - 5) continue;

                grid.SetTile(x, floorY, 'x'); // Golv = x
            }
            // Lägg till en stege (förutom på bottenvåningen)
            if (floor > 0)
            {
                int ladderX = (floor % 2 == 0) ? 5 : width - 6;
                for (int y = floorY; y < floorY + 5; y++)
                {
                    grid.SetTile(ladderX, y, 'H'); // Stege
                }
            }
        }
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