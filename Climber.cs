using System;
using System.Diagnostics.CodeAnalysis;
public class Climber
{
    private int _physicsFrameCounter = 0;

    public Position Position {get; private set;}
    public int HP {get; set;}
    public char Symbol {get; } = '@';
    private PoisonEffect poisonStatus = new PoisonEffect();
    public bool isJumping { get; private set; }
    public int JumpTicksLeft { get; private set; }

    public Climber(Position position, int hp)
    {
        Position = position;
        HP = hp;
    }
    public void MoveTo(Position position) 
    {
        Position = position;
    }
    public void TryJump(Map map)
    {
        if (!isJumping && map.HasGroundBelow(Position))
        {
            StartJump(6);
        }
    }
    public void TryClimb(int deltaY, Map map) //deltaY = +1 eller -1, deltaX = 0 då vi endast vill klättra
    {
        Position newPos = new Position(Position.X, Position.Y + deltaY);

        if(map.IsLadder(newPos))
        {
            MoveTo(newPos);
        }
    }

    public void TryMove(int deltaX, Map map) 
    {
        Position newPos = new Position(Position.X + deltaX, Position.Y);

        if(map.IsWalkable(newPos) && map.HasGroundBelow(newPos))
        {
           MoveTo(newPos);
        }
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
    public void UpdatePhysics(Map map)
    {
        _physicsFrameCounter++;
        if (_physicsFrameCounter < 2) return;
        _physicsFrameCounter = 0;

        if (map.IsLadder(Position))
        {
            CancelJump();
            return;
        }
        if (isJumping)
        {
            if (map.IsWalkable(GetAbovePos()) && !map.IsLadder(GetAbovePos()))
            {
                MoveTo(GetAbovePos());
                DuringJump();
            }
            else
            {
                CancelJump();
            }
            return;
        }
        if (!map.HasGroundBelow(Position))      //om climber faller 
        {
            if (map.IsWalkable(GetBelowPos()))
            {
                MoveTo(GetBelowPos()); 
            }
        }
    } 
    private Position GetBelowPos()
    {
        return new Position(Position.X, Position.Y + 1);
    }
    private Position GetAbovePos()
    {
        return new Position(Position.X, Position.Y - 1);
    }
    public void ApplyPoison() => poisonStatus.Apply();
    public void UpdatePoison() => poisonStatus.Update(HP);
    public void ApplyHeal() => HP =+ 1;
}