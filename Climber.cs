using System;
using System.Diagnostics.CodeAnalysis;
public class Climber
{
    public Position Position {get; set;}
    public Health HP {get; set;}
    public char Symbol {get; } = '@';
    private PoisonEffect poisonStatus = new PoisonEffect();
    public bool isJumping { get; private set; }
    public int JumpTicksLeft { get; private set; }

    public Climber(Position position, Health hp)
    {
        Position = position;
        HP = hp;
    }
    public void MoveTo(Position position) 
    {
        Position = position;
    }
    public void StartJump(int ticks)
    {
        isJumping = true;
        JumpTicksLeft = ticks;
    }
    public void DuringJump()
    {
        JumpTicksLeft--;
        if (JumpTicksLeft <= 0)
        {
            isJumping = false;
        }
    }
    public void CancelJump()
    {
        isJumping = false;
        JumpTicksLeft = 0;
    }

    public void ApplyPoison() => poisonStatus.Apply();
    public void UpdatePoison() => poisonStatus.Update(this.HP);
    public void ApplyHeal() => this.HP.HP =+ 1;
}