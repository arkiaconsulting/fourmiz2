using SkiaSharp;

namespace MainApp;

internal static class Constants
{
    public static readonly SKPaint Blue = new()
    {
        Color = SKColors.Blue,
    };

    public const double MaxFourmizMass = 200;

    public const double MaxFourmizSpeed = 2;
}
