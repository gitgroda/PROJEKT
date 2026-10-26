public class LadderState : ClimberState
{
    public override void HandleClimb(Climber climber, int deltaY, Map map)
    {
        Position pos = climber.GetPosition();
        Position target = new Position(pos.X, pos.Y + deltaY);
        if (map.IsLadder(target))
        {
            climber.MoveTo(target);
        }
        // Låt climber kliva av stegen uppåt om marken är ledig
    else if (deltaY == -1 && map.IsWalkable(target))
    {
        climber.MoveTo(target);
        climber.SetState(new GroundState());
    }
    }

    public override void HandleMove(Climber climber, int deltaX, Map map)
    {
        Position pos = climber.GetPosition();
        Position target = new Position(pos.X + deltaX, pos.Y);
        if (map.IsWalkable(target) && map.HasGroundBelow(target))
        {
            climber.MoveTo(target);
            climber.SetState(new GroundState());
        }
    }

    public override void Update(Climber climber, Map map)
    {
        Position pos = climber.GetPosition();
        if (!map.IsLadder(pos))
        {
            if (map.HasGroundBelow(pos))
            {
                climber.SetState(new GroundState());
            }
            else
            {
                climber.SetState(new FallingState());
            }
        }
    }
}
