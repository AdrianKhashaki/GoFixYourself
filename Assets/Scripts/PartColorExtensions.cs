using System;
using UnityEngine;

public static class PartColorExtensions
{
    public static Color GetColor(this PartColor partColor)
    {
        switch (partColor)
        {
            case PartColor.Red:
                return Color.red;
            case PartColor.Blue:
                return Color.blue;
            case PartColor.Green:
                return Color.green;
            case PartColor.Yellow:
                return Color.yellow;
            default:
                throw new ArgumentOutOfRangeException(nameof(partColor), partColor, null);
        }
    }
}