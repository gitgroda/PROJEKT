using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;

public class Grid
{
    private char[,] tiles;
    private int _width;
    private int _height;

    public Grid(int width, int height) 
    {
        _width = width;
        _height = height;
        tiles = new char[_width, _height]; //2d array tar [X-kordinat, Y-kordnat]
        for (int y = 0; y < _height; y++)
        { 
            for (int x = 0; x < _width; x++)
            {
                tiles[x, y] = ' '; 
            }   
        }
    }
    public void Buildlevel() //göra randomised build level istället för att leveln alltid ser likadan ut? 
    {

        for (int floor = 0; floor < 5; floor++)
        {
            int floorY = _height - 1 - (floor * 5); //Sätter varje våning 5 rader över den förra, golvet börjar på _height - 2 eller _height?
            for(int x = 0; x < _width; x++)
           {
                // Lämnar luckor för tunnorna att falla ner
                if (floor % 2 == 0 && floor != 0 && x < 4) continue;
                if (floor % 2 != 0 && x > _width - 5) continue;

                SetTile(new Position(x, floorY), 'x'); // Golv = x
            }
            // Lägg till en stege (förutom på bottenvåningen)
            if (floor > 0)
            {
                int ladderX = (floor % 2 == 0) ? 5 : _width - 6;
                for (int y = floorY; y < floorY + 5; y++)
                {
                    SetTile(new Position(ladderX, y), 'H'); // Stege
                }
            }
        }
    }
    public void SetTile(Position position, char tile)
    {
        if (position.X >= 0 && position.X < _width && position.Y >= 0 && position.Y < _height)
        {
            tiles[position.X, position.Y] = tile;
        }
    }

    public char GetTile(Position positon)
    {
        if (positon.X < 0 || positon.X >= _width || positon.Y < 0 || positon.Y >= _height)
        {
            return 'x';
        }
        else
        {
            return tiles[positon.X, positon.Y]; 
        }
    }
}