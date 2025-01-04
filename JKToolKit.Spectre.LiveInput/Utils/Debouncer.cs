namespace JKToolKit.Spectre.LiveInput.Utils;

internal class Debouncer
{
    public TimeSpan Interval { get; }
    public DateTime LastCall { get; private set; }

    public bool CanCall => (DateTime.UtcNow - LastCall) > Interval;

    public Debouncer(TimeSpan interval)
    {
        Interval = interval;
        
        var doubleInterval = TimeSpan.FromTicks(interval.Ticks * 2);
        LastCall = DateTime.UtcNow - doubleInterval;
    }

    public void Call()
    {
        LastCall = DateTime.UtcNow;
    }
    
    public bool TryCall()
    {
        if (CanCall)
        {
            Call();
            return true;
        }

        return false;
    }
}
