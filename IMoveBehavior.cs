// FALL #1: IMoveBehavior
// VAD är det för koncept ni påstår att ni använder?
// Strategy Pattern
// HUR använder ni konceptet?
// Genom gränssnittet IMoveBehavior injiceras olika rörelsestrategier (BouncingBehavior, RollingBehavior) in i spelobjekt som Movable (barrel) via konstruktorn.
// VARFÖR använder ni konceptet?
// För att dynamiskt variera hur objekt rör sig utan att bygga fast logiken i objektets klass. 
// Det gör koden mer modulär, eliminerar subtyper av Barrel och gör det enkelt att lägga till nya rörelsemönster.
public interface IMoveBehavior
{
Position Move (Position currentPosition, Map map);
}