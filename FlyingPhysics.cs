public class FlyingPhysics : IClimberPhysics
{
    private int _flightTicksLeft = 0;
    private int _glideCounter = 0;

    public void Move(Climber climber, int deltaX, Map map)
    {
        Position pos = climber.GetPosition();
        Position target = new Position(pos.X + deltaX, pos.Y);
        // Full frihet: kan flyga horisontellt i luften utan markkrav
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
        // Vingslag/Jetpack: kan lyfta i luften när som helst (multi-jump)
        _flightTicksLeft = 3;
    }

    public void Update(Climber climber, Map map)
    {
        Position pos = climber.GetPosition();
        if (map.IsLadder(pos)) return;

        if (_flightTicksLeft > 0)
        {
            if (map.IsWalkable(pos.GetAbove())) climber.MoveTo(pos.GetAbove());
            _flightTicksLeft--;
            return;
        }

        // Glidflykt: faller mycket långsamt (endast vart 3:e tick)
        if (!map.HasGroundBelow(pos) && ++_glideCounter % 3 == 0)
        {
            if (map.IsWalkable(pos.GetBelow())) climber.MoveTo(pos.GetBelow());
        }
    }
}