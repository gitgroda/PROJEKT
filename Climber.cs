using System;

public class Climber
{
    private IClimberPhysics _physics;
    private PoisonEffect _poisonStatus = new PoisonEffect();
    private Position _position;
    private int _hp;
    private char _symbol = '@';
    private bool _isWinning = false;
    private int _physicsFrameCounter = 0;

    public Climber(int hp, IClimberPhysics physics)
    {
        _position = new Position(5, 22);
        _hp = hp;
        _physics = physics;
    }

    public void TakeDamage() => _hp -= 3;
    public int GetHP() => _hp;
    public bool IsDead() => _hp <= 0;
    public bool Winning() => _isWinning = true;
    public bool Win() => _isWinning;
    public void ApplyPoison() => _poisonStatus.Apply();
    public void ApplyHeal() => _hp += 3;

    public Position GetPosition() => _position;
    public void MoveTo(Position position) => _position = position;
    public void SetPhysics(IClimberPhysics physics) => _physics = physics;

    public void Draw(IRenderer renderer)
    {
        renderer.DrawSprite(_position, _symbol, ConsoleColor.White);
    }

    public bool IsCollidingWith(IGameObject obj)
    {
        return obj.IsAt(_position);
    }

    public void TryClimb(int deltaY, Map map)
    {
        _physics.Climb(this, deltaY, map);
    }

    public void TryMove(int deltaX, Map map)
    {
        _physics.Move(this, deltaX, map);
    }

    public void TryJump(Map map)
    {
        _physics.Jump(this, map);
    }

    public void UpdatePhysics(Map map)
    {
        _physicsFrameCounter++;
        if (_physicsFrameCounter < 2) return;
        _physicsFrameCounter = 0;

        _physics.Update(this, map);
    }

    public void UpdateEffects()
    {
        if (_poisonStatus.ShouldDamage())
        {
            _hp -= 2;
        }
    }
    
}
