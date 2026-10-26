// FALL #5:
// VAD är det för koncept ni påstår att ni använder?
// State Pattern
// HUR använder ni konceptet?
// IClimberState implementeras av GroundState, JumpingState, FallingState
// och LadderState. Climber delegerar tillståndsspecifik logik dit.
// VARFÖR använder ni konceptet?
// Ersätter komplexa flaggor och villkor i Climber med polymorfism.
// Varje rörelsetillstånd kapslar sin egen fysik i korta metoder.
public interface IClimberState
{
    void HandleMove(Climber climber, int deltaX, Map map);
    void HandleClimb(Climber climber, int deltaY, Map map);
    void HandleJump(Climber climber, Map map);
    void Update(Climber climber, Map map);
}
