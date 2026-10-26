using System;
using System.Diagnostics.CodeAnalysis;
public class Climber
{
    private int _physicsFrameCounter = 0;

    private Position _position;
    private int _hp;
    private char _symbol = '@';
    private PoisonEffect _poisonStatus = new PoisonEffect();
    private bool _isJumping;
    private int _jumpTicksLeft;
    public void TakeDamage() => _hp -= 3;
  

    public Climber(int hp)
    {
        _position = new Position(5, 22);
        _hp = hp;
    }
    public void Draw(IRenderer renderer)
    {
        renderer.DrawSprite(_position, _symbol, ConsoleColor.White);
    }
    public bool IsCollidingWith(IGameObject obj)
    {
        return obj.IsAt(_position);
    }
    public void MoveTo(Position position) 
    {
        _position = position;
    }

    public void TryClimb(int deltaY, Map map) //deltaY = +1 eller -1, deltaX = 0 då vi endast vill klättra
    {
        Position newPos = new Position(_position.X, _position.Y + deltaY);

        if(map.IsLadder(newPos))
        {
            MoveTo(newPos);
        }
    }

    public int GetHP() => _hp;
    public void TryMove(int deltaX, Map map) 
    {
        Position newPos = new Position(_position.X + deltaX, _position.Y);

        if(map.IsWalkable(newPos) && map.HasGroundBelow(newPos))
        {
           MoveTo(newPos);
        }
    }
    public void TryJump(Map map)
    {
        if (!_isJumping && map.HasGroundBelow(_position))
        {
            _isJumping = true;
            _jumpTicksLeft = 6;
        }
    }
    public void UpdatePhysics(Map map)
    {
        _physicsFrameCounter++;
        if (_physicsFrameCounter < 2) return;
        _physicsFrameCounter = 0;

        if (map.IsLadder(_position))
        {
            _isJumping = false;
            _jumpTicksLeft = 0;
            return;
        }
        if (_isJumping)
        {
            if (map.IsWalkable(_position.GetAbove()) && !map.IsLadder(_position.GetAbove()))
            {
                MoveTo(_position.GetAbove());
                _jumpTicksLeft--;
                if (_jumpTicksLeft <= 0)
                {
                    _isJumping = false;
                }
            }
            else
            {
                _isJumping = false;
                _jumpTicksLeft = 0;
            }
            return;
        }
        if (!map.HasGroundBelow(_position))      //om climber faller 
        {
            if (map.IsWalkable(_position.GetBelow()))
            {
                _position = _position.GetBelow(); 
            }
        }
    } 
    public void UpdateEffects()
    {
        if (_poisonStatus.ShouldDamage()) _hp -=2;
    }
    public bool IsDead() => _hp <= 0;
    public void ApplyPoison() => _poisonStatus.Apply();
    public void ApplyHeal() => _hp += 3;
}