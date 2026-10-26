public class GroundState : ClimberState
{
    public override void HandleJump(Climber climber, Map map)
    {
        if (map.HasGroundBelow(climber.GetPosition()))
        {
            climber.SetState(new JumpState(6));
        }
    }
    public override void HandleClimb(Climber climber, int deltaY, Map map)
    {
        Position pos = climber.GetPosition();
        Position target = new Position(pos.X, pos.Y + deltaY);
        if (map.IsLadder(target))
        {
            climber.MoveTo(target);
            climber.SetState(new LadderState());
        }
    }
    public override void Update(Climber climber, Map map)
    {
        Position pos = climber.GetPosition();
        if (map.IsLadder(pos))
        {
            climber.SetState(new LadderState());
            return;
        }

        if (!map.HasGroundBelow(pos))
        {
            climber.SetState(new FallingState());
        }
    }
}
