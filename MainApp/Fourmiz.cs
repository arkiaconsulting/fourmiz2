using Silk.NET.Maths;
using SkiaSharp;

namespace MainApp;

internal sealed class Fourmiz
{
    private static readonly Random _random = new();
    private Vector2D<double> _position;
    private readonly Vector2D<double> _worldBoundaries;
    private Vector2D<double> _velocity = Vector2D<double>.Zero;
    private readonly Vector2D<double> _steeringForce = Some.RandomNormalizedVector * 100;
    private readonly double _mass = double.Clamp(_random.NextDouble() * Constants.MaxFourmizMass, Constants.MaxFourmizMass / 8, Constants.MaxFourmizMass);
    private readonly double _maxSpeed = double.Clamp(_random.NextDouble() * Constants.MaxFourmizSpeed, Constants.MaxFourmizSpeed / 2, Constants.MaxFourmizSpeed);

    public Fourmiz(Vector2D<double> initialPosition, Vector2D<double> worldBoundaries)
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

        var acceleration = _steeringForce / _mass;
        var dv = acceleration * elapsed;
        _velocity += dv;
        _velocity = Vector2D.Clamp(_velocity, Vector2D<double>.Zero, Vector2D.Normalize(Vector2D<double>.One) * _maxSpeed);
        _position += _velocity;
    }

    public void Draw(SKCanvas canvas)
    {
        canvas.DrawCircle((float)_position.X, (float)_position.Y, 10, Constants.Blue);
    }
}