using Silk.NET.Maths;

namespace MainApp;

internal static class Vector2DExtensions
{
    public static Vector2D<double> Truncate(this Vector2D<double> vector, double max)
    {
        if (vector.LengthSquared > max * max)
        {
            return Vector2D.Normalize(vector) * max;
        }

        return vector;
    }
}
