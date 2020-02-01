using System;

public static class UtilExtensions
{
    public static TimeSpan FromSeconds(this float seconds)
    {
        return new TimeSpan(0, 0, 0, 0, (int) (seconds * 1000));
    }
}