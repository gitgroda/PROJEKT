using System;
using System.Diagnostics.CodeAnalysis;
public class Climber
{
    public Health HP {get; set;}
    public char Symbol {get; } = '@';
    private PoisonEffect poisonStatus = new PoisonEffect();

    

    public Climber(Health hp)
    {
       HP = hp;
    }
    public void MoveTo(int targetX, int targetY) 
    {
        

    }
    public void ApplyPoison()
    {
        poisonStatus.Apply();
    
    }
    public void UpdatePoison()
    {
        poisonStatus.Update(this.HP);
    }
}