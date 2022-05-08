using System.Diagnostics;

public class SpeedcubingTimer
{
    bool onGoing = false;
    double minutes, seconds, milliSeconds;
    Stopwatch stopWatch = new Stopwatch();

    public void Start()
    {
        stopWatch.Restart();
        onGoing = true;
    }

    public string GetTime()
    {
        minutes = stopWatch.Elapsed.Minutes;
        seconds = stopWatch.Elapsed.Seconds;
        milliSeconds = stopWatch.Elapsed.Milliseconds;

        seconds += minutes * 60;

        return $"{seconds},{milliSeconds}s";
    }

    public double GetDoubleTime()
    {
        minutes = stopWatch.Elapsed.Minutes;
        seconds = stopWatch.Elapsed.Seconds;
        milliSeconds = stopWatch.Elapsed.Milliseconds;

        seconds += minutes * 60;

        return seconds + (milliSeconds / 1000);
    }

    public string StopAndGetTime()
    {
        minutes = stopWatch.Elapsed.Minutes;
        seconds = stopWatch.Elapsed.Seconds;
        milliSeconds = stopWatch.Elapsed.Milliseconds;

        seconds += minutes * 60;

        stopWatch.Stop();
        onGoing = false;

        return $"{seconds},{milliSeconds}s";
    }

    public bool OnGoing { get => onGoing; }
    public long ElapsedMilliseconds { get => stopWatch.ElapsedMilliseconds; }
    
}