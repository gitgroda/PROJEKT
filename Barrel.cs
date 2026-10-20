public class Barrel : IGameObject
{
    public Position Position;
    public IBarrelType Type;
    public char Symbol {get;}
    public Barrel(Position position, IBarrelType type)
    {
        Position = position;
        Type = type;
        Symbol = type.Symbol;
    } 
        public Position GetPos()
    {
        return Position;
    }
}