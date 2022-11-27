using UnityEngine;

public static class RGBLerp
{
    public static Color Lerp(float time)
    { 
        if (time <= 1) return Color.Lerp(Color.blue, Color.magenta, time);
        else if (time <= 2) return Color.Lerp(Color.magenta, Color.red, time - 1);
        else return Color.Lerp(Color.red, Color.green, time - 2);
    }
}
