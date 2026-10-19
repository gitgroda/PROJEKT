using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;

public class Grid
{
    public char[,] tiles;
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
                if (y == 0 || y == Height - 1 || x == 0 || x == Width - 1) //skriver ut border
                {
                    tiles[x, y] = 'x';
                }
                else
                {
                    tiles[x, y] = '-'; 
                }
            }   
        }
    }
    public void Print()
    {
        System.Console.WriteLine();
        for (int y = 0; y < Height; y++)
        { 
            for (int x = 0; x < Width; x++)
            {
                System.Console.Write(tiles[x, y]);
            }   
            System.Console.WriteLine();  
        }
        System.Console.WriteLine();
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