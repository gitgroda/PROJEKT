using System;

public class PoisonEffect
{
    private bool isActive = false;
    private DateTime poisonStartTime;
    private DateTime lastPoisonDamageTime;
    private int poisonDamageIntervall = 3000;
    private int poisonDuration = 10000;
    public void Apply()
    {
        isActive = true;
        DateTime now = DateTime.Now;
        poisonStartTime = now;
        lastPoisonDamageTime = now;
    }
    public void Update(Health targetHealth)
    {
        if (!isActive) return; 

        DateTime now = DateTime.Now;
        
        if ((now - poisonStartTime).TotalMilliseconds >= poisonDuration)
        {
            isActive = false;
            return;
        }

        if ((now - lastPoisonDamageTime).TotalMilliseconds >= poisonDamageIntervall)
        {
            targetHealth.HP -= 1; // (Anpassa efter hur din Health-klass ser ut)
            lastPoisonDamageTime = now;
        }
}
}