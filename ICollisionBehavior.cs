// FALL #2:
// VAD är det för koncept ni påstår att ni använder?
// Strategy Pattern
// HUR använder ni konceptet?
// Gränssnittet ICollisionBehavior definierar kollisionslogik. Olika instanser (NormalCollide, PoisonCollide, Heal) injiceras i objekt som Potion och Barrel vid skapandet.
// VARFÖR använder ni konceptet?
// Det ersätter komplexa if/switch-satser i kollisionshanteringen med polymorfism. Varje strategi hanterar sitt unika beteende fristående, vilket kraftigt ökar testbarheten och läsbarheten.
public interface ICollisionBehavior
{
    ConsoleColor GetEffectColor();
    void Collide(Climber climber);
}