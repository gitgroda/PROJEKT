using System;

public class PoisonEffect
{
    private bool _isActive = false;
    private DateTime _poisonStartTime;
    private DateTime _lastPoisonDamageTime;
    private int _poisonDamageIntervall = 3000;
    private int _poisonDuration = 10000;
    public void Apply()
    {
        _isActive = true;
        DateTime now = DateTime.Now;
        _poisonStartTime = now;
        _lastPoisonDamageTime = now;
    }
    public bool ShouldDamage()
    {
        if (!_isActive) return false;

        DateTime now = DateTime.Now;
        if ((now - _poisonStartTime).TotalMilliseconds >= _poisonDuration)
        {
            _isActive = false;
            return false;
        }
        if ((now - _lastPoisonDamageTime).TotalMilliseconds >= _poisonDamageIntervall)
        {
            _lastPoisonDamageTime = now;
            return true; // 
        }
        return false;
    }
}