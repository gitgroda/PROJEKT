public class LowGravityPhysics : IClimberPhysics
{
    private int _jumpTicksLeft = 0;
    private int _fallTickCounter = 0;

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
        Position belowTarget = new Position(pos.X, pos.Y + deltaY + 1);

        if (map.IsLadder(target) || map.IsLadder(pos) && map.IsWalkable(belowTarget))
        {
            climber.MoveTo(target);
        }
    }
    public void Jump(Climber climber, Map map)
    {
        Position pos = climber.GetPosition();
        if (map.HasGroundBelow(pos) && _jumpTicksLeft == 0)
        {
            _jumpTicksLeft = 6;
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
            _fallTickCounter++;
            if (_fallTickCounter % 2 == 0)
            {
                Position below = pos.GetBelow();
                if (map.IsWalkable(below)) climber.MoveTo(below);
            }
        }
    }
}
