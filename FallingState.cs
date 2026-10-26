public class FallingState : ClimberState
{
    public override void Update(Climber climber, Map map)
    {
        Position pos = climber.GetPosition();
        if (map.IsLadder(pos))
        {
            climber.SetState(new LadderState());
            return;
        }

        if (map.HasGroundBelow(pos))
        {
            climber.SetState(new GroundState());
            return;
        }

        Position below = pos.GetBelow();
        if (map.IsWalkable(below))
        {
            climber.MoveTo(below);
        }
    }
}
