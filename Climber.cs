using System;

public class Climber
{
    private int _physicsFrameCounter = 0;
    private Position _position;
    private int _hp;
    private char _symbol = '@';
    private PoisonEffect _poisonStatus = new PoisonEffect();
    private IClimberState _state;

    public Climber(int hp)
    {
        _position = new Position(5, 22);
        _hp = hp;
        _state = new GroundState();
    }

    public void TakeDamage() => _hp -= 3;
    public int GetHP() => _hp;
    public bool IsDead() => _hp <= 0;
    public void ApplyPoison() => _poisonStatus.Apply();
    public void ApplyHeal() => _hp += 3;

    public Position GetPosition() => _position;
    public void MoveTo(Position position) => _position = position;
    public void SetState(IClimberState state) => _state = state;

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
        _state.HandleClimb(this, deltaY, map);
    }

    public void TryMove(int deltaX, Map map)
    {
        _state.HandleMove(this, deltaX, map);
    }

    public void TryJump(Map map)
    {
        _state.HandleJump(this, map);
    }

    public void UpdatePhysics(Map map)
    {
        _physicsFrameCounter++;
        if (_physicsFrameCounter < 2) return;
        _physicsFrameCounter = 0;

        _state.Update(this, map);
    }

    public void UpdateEffects()
    {
        if (_poisonStatus.ShouldDamage())
        {
            _hp -= 2;
        }
    }
}
