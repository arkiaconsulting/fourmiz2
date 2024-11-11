using SkiaSharp;

namespace MainApp;

internal static class Constants
{
    public static readonly Random Randomizer = new();

    public static readonly SKPaint Blue = new()
    {
        Color = SKColors.Blue,
    };

    public static readonly SKPaint Green = new()
    {
        Color = SKColors.Green,
    };

    public const double MaxFourmizMass = 200;

    public const double MaxFourmizSpeed = 2;
}
