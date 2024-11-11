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

    public static readonly SKPaint Black = new()
    {
        Color = SKColors.Black,
    };

    public static readonly SKPaint BlackOutlined = new()
    {
        Color = SKColors.Black,
        Style = SKPaintStyle.Stroke,
    };

    public static readonly SKPaint LightGreen = new()
    {
        Color = SKColors.LightGreen,
    };

    public static SKPaint Orange = new()
    {
        Color = SKColors.Orange,
    };

    public static SKPaint Red = new()
    {
        Color = SKColors.Red,
    };

    public static SKPaint Brown = new()
    {
        Color = SKColors.Brown,
    };

    public const double MaxFourmizMass = 200;

    public const double MaxFourmizSpeed = 2;
}
