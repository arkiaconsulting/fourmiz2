using Silk.NET.Maths;
using SkiaSharp;

namespace MainApp;

internal sealed class FoodSpot
{
    private readonly Vector2D<double> _position;
    private const float Size = 30;
    private float _foodStock = 1000;

    public FoodSpot(Vector2D<double> position) => _position = position;

    public void Draw(SKCanvas canvas)
    {
        canvas.DrawRect((float)_position.X, (float)_position.Y, Size, Size, Constants.Green);
    }
}