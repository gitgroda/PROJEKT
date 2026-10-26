public abstract class ClimberState : IClimberState
{
    public virtual void HandleMove(Climber climber, int deltaX, Map map)
    {
        Position pos = climber.GetPosition();
        Position target = new Position(pos.X + deltaX, pos.Y);
        if (map.IsWalkable(target) && map.HasGroundBelow(target))
        {
            climber.MoveTo(target);
        }
    }

    public virtual void HandleClimb(Climber climber, int deltaY, Map map)
    {
    }

    public virtual void HandleJump(Climber climber, Map map)
    {
    }

    public abstract void Update(Climber climber, Map map);
}
