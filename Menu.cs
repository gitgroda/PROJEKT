using System;
using System.Collections.Generic;

// FALL #5: Menu
// VAD är det för koncept ni påstår att ni använder?
// Generics 
// HUR använder ni konceptet?
// Klasserna Menu<T> och MenuItem<T> använder en typ-parameter T som representerar den datatyp menyn ska returnera när spelaren gör ett val.
// VARFÖR använder ni konceptet?
// För att bygga ett återanvändbart och typsäkert menysystem. 
// Menyn kan användas för att returnera en Action för en huvudmeny, eller en Enum för att välja svårighetsgrad. 
public class Menu<T>
{
    private readonly string _title;
    private readonly IReadOnlyList<MenuItem<T>> _items;
    private int _selectedIndex = 0;

    public Menu(string title, IReadOnlyList<MenuItem<T>> items)
    {
        _title = title;
        _items = items;
    }

    public T Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"=== {_title} ===");
            Console.WriteLine();
            for (int i = 0; i < _items.Count; i++)
            {
                if (i == _selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"> {_items[i].Text}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {_items[i].Text}");
                }
            }
            ConsoleKey key = Console.ReadKey(intercept: true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow or ConsoleKey.W:
                    _selectedIndex = (_selectedIndex - 1 + _items.Count) % _items.Count;
                    break;
                case ConsoleKey.DownArrow or ConsoleKey.S:
                    _selectedIndex = (_selectedIndex + 1) % _items.Count;
                    break;
                case ConsoleKey.Enter or ConsoleKey.Spacebar:
                    return _items[_selectedIndex].Value; 
            }
        }
    }
}