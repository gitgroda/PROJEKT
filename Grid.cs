using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;

public class Grid
{
    private char[,] tiles;
    public int Width { get; }
    public int Height { get; }

    public Grid(int width, int height) 
    {
        this.Width = width;
        this.Height = height;
        this.tiles = new char[Width, Height]; //2d array tar [X-kordinat, Y-kordnat]
        for (int y = 0; y < Height; y++)
        { 
            for (int x = 0; x < Width; x++)
            {
                tiles[x, y] = ' '; 
            }   
        }
        Buildlevel();
    }
    private void Buildlevel() //göra randomised build level istället för att leveln alltid ser likadan ut? 
    {
        int width = Width;
        int height = Height;

        for (int floor = 0; floor < 5; floor++)
        {
            int floorY = height - 1 - (floor * 5); //Sätter varje våning 5 rader över den förra, golvet börjar på height - 2 eller height?
            for(int x = 0; x < width; x++)
           {
                // Lämnar luckor för tunnorna att falla ner
                if (floor % 2 == 0 && floor != 0 && x < 4) continue;
                if (floor % 2 != 0 && x > width - 5) continue;

                SetTile(new Position(x, floorY), 'x'); // Golv = x
            }
            // Lägg till en stege (förutom på bottenvåningen)
            if (floor > 0)
            {
                int ladderX = (floor % 2 == 0) ? 5 : width - 6;
                for (int y = floorY; y < floorY + 5; y++)
                {
                    SetTile(new Position(ladderX, y), 'H'); // Stege
                }
            }
        }
    }
    public void SetTile(Position position, char tile)
    {
        if (position.X >= 0 && position.X < Width && position.Y >= 0 && position.Y < Height)
        {
            tiles[position.X, position.Y] = tile;
        }
    }

    public char GetTile(Position positon)
    {
        if (positon.X < 0 || positon.X >= Width || positon.Y < 0 || positon.Y >= Height)
        {
            return 'x';
        }
        else
        {
            return tiles[positon.X, positon.Y]; 
        }
    }

}