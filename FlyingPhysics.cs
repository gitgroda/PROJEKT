using System.Security.Claims;

public class FlyingPhysics : IClimberPhysics
{
    private int _flyingTicksLeft = 0;
    private int _glideCounter = 0;

    public void Move(Climber climber, int deltaX, Map map)
    {
        Position pos = climber.GetPosition();
        Position target = new Position(pos.X + deltaX, pos.Y);
        if (map.IsWalkable(target))
        {
            climber.MoveTo(target);
        }
    }

    public void Climb(Climber climber, int deltaY, Map map)
    {
        Position pos = climber.GetPosition();
        Position target = new Position(pos.X, pos.Y + deltaY);
        if (map.IsLadder(target) || map.IsLadder(pos))
        {
            climber.MoveTo(target);
        }
    }

    public void Jump(Climber climber, Map map)
    {
        _flyingTicksLeft++;
    }

    public void Update(Climber climber, Map map)
    {
        Position pos = climber.GetPosition();
        if (map.IsLadder(pos)) return;

        if (_flyingTicksLeft > 0)
        {
            if (map.IsWalkable(pos.GetAbove()))
            {
                climber.MoveTo(pos.GetAbove());
                _flyingTicksLeft--;
            }
        }
        if (!map.HasGroundBelow(pos) && ++_glideCounter % 5 == 0)
        {
            Position below = pos.GetBelow();
            if (map.IsWalkable(below))
            {
                climber.MoveTo(below);
            }
        }

      
    }
}