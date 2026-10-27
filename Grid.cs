using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
// FALL #6: Grid
// VAD är det för koncept ni påstår att ni använder?
// Generics
// HUR använder ni konceptet?
// Egen generisk typ Grid<T> som konstrueras med två olika typargument:
// Grid<char> för grafiska tecken och Grid<bool> för solida objekt samt stegar.
// VARFÖR använder ni konceptet?
// Återanvänder 2D-rutnätslogik, indexering och gränskontroller för olika
// datatyper utan kodduplikation eller typkonvertering.
public class Grid<T>
{
    private T[,] _tiles;
    private int _width;
    private int _height;
    public Grid(int width, int height, T defaultValue) 
    {
        _width = width;
        _height = height;
        _tiles = new T[_width, _height]; 
        for (int y = 0; y < _height; y++)
        { 
            for (int x = 0; x < _width; x++)
            {
                _tiles[x, y] = defaultValue; 
            }
        }
    }
    public bool IsOutOfBounds(Position pos)
    {
        return pos.X < 0 || pos.X >= _width || pos.Y < 0 || pos.Y >= _height;
    }
    public void Set(Position pos, T value)
    {
        if (!IsOutOfBounds(pos))
        {
            _tiles[pos.X, pos.Y] = value;
        }
    } 
    public T Get(Position pos, T fallback)
    {
        if (IsOutOfBounds(pos))
        {
            return fallback;
        }
        return _tiles[pos.X, pos.Y];
    }
}
   