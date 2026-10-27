// FALL #3:
// VAD är det för koncept ni påstår att ni använder?
// Strategy Pattern
// HUR använder ni konceptet?
// IClimberPhysics implementeras av StandardPhysics, LowGravityPhysics, HeavyPhysics
//
// VARFÖR använder ni konceptet?
//
public interface IClimberPhysics
{
    void Move(Climber climber, int deltaX, Map map);
    void Jump(Climber climber, Map map);
    void Update(Climber climber, Map map);
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

    
}
