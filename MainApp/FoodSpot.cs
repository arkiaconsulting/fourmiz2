using Silk.NET.Maths;
using SkiaSharp;

namespace MainApp;

internal sealed class FoodSpot
{
    public const float Size = 30;
    public Vector2D<double> Position => _position;
    public bool IsDepleted => _foodStock <= 0;

    private readonly Vector2D<double> _position;
    private double _foodStock = 100;

    public FoodSpot(Vector2D<double> position) => _position = position;

    public void Draw(SKCanvas canvas)
    {
        if (IsDepleted)
        {
            canvas.DrawRect((float)_position.X - Size / 2, (float)_position.Y - Size / 2, Size, Size, Constants.Brown);

            return;
        }

        canvas.DrawRect((float)_position.X - Size / 2, (float)_position.Y - Size / 2, Size, Size, Constants.Green);
    }

    internal double Harvest(double quantity)
    {
        if (_foodStock <= 0)
        {
            return 0;
        }

        var harvested = quantity > _foodStock ? _foodStock : quantity;

        _foodStock -= harvested;

        return harvested;
    }
}