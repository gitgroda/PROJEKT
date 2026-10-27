// FALL #2: ICollisionBehavior
// VAD är det för koncept ni påstår att ni använder?
// Strategy Pattern
// HUR använder ni konceptet?
// Gränssnittet ICollisionBehavior definierar kollisionslogik. Olika instanser (NormalCollide, PoisonCollide, HealCollide) injiceras i objekten Static (potion, firetrap) och Movable (barrel) vid skapandet.
// VARFÖR använder ni konceptet?
// För att dynamiskt variera hur objekt rör sig utan att bygga fast logiken i objektets klass. 
// Det gör koden mer modulär, eliminerar subtyper av Movable och gör det enkelt att lägga till nya kollisionsmönster.
public interface ICollisionBehavior
{
    ConsoleColor GetEffectColor();
    void Collide(Climber climber);
}