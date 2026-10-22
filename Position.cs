public readonly record struct Position
{
    public int X { get; }
    public int Y { get; }
    
    public Position(int X, int Y)
    {
        this.X = X;
        this.Y = Y;
    }
}