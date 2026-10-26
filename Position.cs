public readonly record struct Position
{
    public int X { get; }
    public int Y { get; }
    
    public Position(int X, int Y)
    {
        this.X = X;
        this.Y = Y;
    }

    public Position GetBelow() => new Position(this.X, this.Y + 1);
    public Position GetAbove() => new Position(this.X, this.Y + -1);

}