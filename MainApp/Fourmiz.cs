using SkiaSharp;

namespace MainApp;

internal sealed class Fourmiz
{
    private SKPoint _position;
    private readonly SKPoint _worldBoundaries;

    public Fourmiz(SKPoint initialPosition, SKPoint worldBoundaries)
    {
        _position = initialPosition;
        _worldBoundaries = worldBoundaries;
    }

    public void Update(double elapsed)
    {
        if (_position.X > _worldBoundaries.X)
        {
            _position.X = 0;
        }

        if (_position.Y > _worldBoundaries.Y)
        {
            _position.Y = 0;
        }

        _position.Offset(1, 1);
    }

    public void Draw(SKCanvas canvas)
    {
        canvas.DrawCircle(_position, 10, Constants.Blue);
    }
}