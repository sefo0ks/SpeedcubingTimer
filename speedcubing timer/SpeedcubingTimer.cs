using System.Diagnostics;

public class SpeedcubingTimer
{
    bool onGoing = false;
    double second, milliSeconds;
    Stopwatch stopWatch = new Stopwatch();

    public void Start()
    {
        stopWatch.Restart();
        onGoing = true;
    }

    public string GetTime()
    {
        second = stopWatch.Elapsed.Seconds;
        milliSeconds = stopWatch.Elapsed.Milliseconds;

        return $"{second},{milliSeconds}s";
    }

    public double GetDoubleTime()
    {
        second = stopWatch.Elapsed.Seconds;
        milliSeconds = stopWatch.Elapsed.Milliseconds;

        return second + (milliSeconds / 1000);
    }

    public string StopAndGetTime()
    {
        second = stopWatch.Elapsed.Seconds;
        milliSeconds = stopWatch.Elapsed.Milliseconds;
        stopWatch.Stop();
        onGoing = false;

        return $"{second},{milliSeconds}s";
    }

    public bool OnGoing { get => onGoing; }
    public long ElapsedMilliseconds { get => stopWatch.ElapsedMilliseconds; }
    
}