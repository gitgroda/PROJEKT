using System.Formats.Tar;

public class NormalBarrel : IBarrelType
{
    private Position position;
    public char Symbol {get;} = 'Ø';
    private int damage = 1;
    public NormalBarrel(Position position)
    {
        this.position = position;
    }


    public void Damage(Climber climber)
    {
        climber.HP.HP =- damage;
    }
}