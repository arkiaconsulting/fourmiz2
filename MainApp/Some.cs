using Silk.NET.Maths;

namespace MainApp;

internal static class Some
{
    public static Vector2D<double> RandomNormalizedVector =>
        new(Random.Shared.NextDouble() - 0.5, Random.Shared.NextDouble() - 0.5);
}
