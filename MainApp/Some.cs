using Silk.NET.Maths;

namespace MainApp;

internal static class Some
{
    public static Vector2D<double> RandomNormalizedVector =>
        new(Constants.Randomizer.NextDouble() - 0.5, Constants.Randomizer.NextDouble() - 0.5);
}
