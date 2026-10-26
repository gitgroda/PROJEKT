public class JumpState : ClimberState
{
    private int _jumpTicksLeft;

    public JumpState(int ticks)
    {
        _jumpTicksLeft = ticks;
    }

    public override void Update(Climber climber, Map map)
    {
        Position pos = climber.GetPosition();
        if (map.IsLadder(pos))
        {
            climber.SetState(new LadderState());
            return;
        }

        Position above = pos.GetAbove();
        bool canMoveUp = map.IsWalkable(above) && !map.IsLadder(above);
        if (canMoveUp && _jumpTicksLeft > 0)
        {
            climber.MoveTo(above);
            _jumpTicksLeft--;
            return;
        }

        climber.SetState(new FallingState());
    }
}
