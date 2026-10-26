// FALL #3:
// VAD är det för koncept ni påstår att ni använder?
// Strategy Pattern
// HUR använder ni konceptet?
// IClimberPhysics implementeras av StandardPhysics, LowGravityPhysics
//
// VARFÖR använder ni konceptet?
//
public interface IClimberPhysics
{
    void Move(Climber climber, int deltaX, Map map);
    void Climb(Climber climber, int deltaY, Map map);
    void Jump(Climber climber, Map map);
    void Update(Climber climber, Map map);
}
