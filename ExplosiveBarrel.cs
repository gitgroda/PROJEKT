public class ExplosiveBarrel : IBarrelType
{
    public char Symbol {get;} = '⦻';
    private int damage = 2;
    public void Damage(Climber climber)
    {
        climber.HP.HP =- damage;
    }
}