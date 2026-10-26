public class StandardPhysics : IClimberPhysics
{
    private int _jumpTicksLeft = 0;

    public void Move(Climber climber, int deltaX, Map map)
    {
        Position pos = climber.GetPosition();
        Position target = new Position(pos.X + deltaX, pos.Y);
        if (map.IsWalkable(target) && map.HasGroundBelow(target))
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
        Position pos = climber.GetPosition();
        if (map.HasGroundBelow(pos) && _jumpTicksLeft == 0)
        {
            _jumpTicksLeft = 3;
        }
    }

    public void Update(Climber climber, Map map)
    {
        Position pos = climber.GetPosition();
        if (map.IsLadder(pos)) return;

        if (_jumpTicksLeft > 0)
        {
            Position above = pos.GetAbove();
            if (map.IsWalkable(above)) climber.MoveTo(above);
            _jumpTicksLeft--;
            return;
        }

        if (!map.HasGroundBelow(pos))
        {
            Position below = pos.GetBelow();
            if (map.IsWalkable(below)) climber.MoveTo(below);
        }
    }
}