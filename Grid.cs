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

    }
public void SetTile(int x, int y, char tile)
    {
        if (x >= 0 && x < Width && y >= 0 && y < Height)
        {
            tiles[x, y] = tile;
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