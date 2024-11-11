using SkiaSharp;

namespace MainApp;

internal static class Constants
{
    public static readonly SKPaint Blue = new()
    {
        Color = SKColors.Blue,
    };

    public const double MaxFourmizMass = 100;

    public const double MaxFourmizSpeed = 3;
}
