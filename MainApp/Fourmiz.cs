using Silk.NET.Maths;
using SkiaSharp;

namespace MainApp;

internal sealed class Fourmiz
{
    private static readonly Random _random = new();
    private Vector2D<double> _position;
    private readonly Vector2D<double> _worldBoundaries;
    private Vector2D<double> _velocity = Some.RandomNormalizedVector / 1000;
    private readonly double _mass = double.Clamp(_random.NextDouble() * Constants.MaxFourmizMass, Constants.MaxFourmizMass / 8, Constants.MaxFourmizMass);
    private readonly double _maxSpeed = double.Clamp(_random.NextDouble() * Constants.MaxFourmizSpeed, Constants.MaxFourmizSpeed / 3, Constants.MaxFourmizSpeed);
    private double _wanderAngle = 0;
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

        if (_position.X < 0)
        {
            _position.X = _worldBoundaries.X;
        }

        if (_position.Y < 0)
        {
            _position.Y = _worldBoundaries.Y;
        }

        var wander = Wander();
        var acceleration = wander / _mass;
        var dv = acceleration * elapsed;
        _velocity += dv;
        _velocity = _velocity.Truncate(_maxSpeed);
        _position += _velocity;
    }

    public void Draw(SKCanvas canvas)
    {
        canvas.DrawCircle((float)_position.X, (float)_position.Y, 10, Constants.Blue);
    }

    private Vector2D<double> Wander()
    {
        if (_velocity == Vector2D<double>.Zero)
        {
            return Vector2D<double>.Zero;
        }

        var circleDistance = 300;
        var circleRadius = 300;
        var angleChange = 45;

        // Calculate the circle center
        var circleCenter = Vector2D.Normalize(_velocity) * circleDistance;

        // Calculate the displacement force
        var displacement = new Vector2D<double>(0, -1) * circleRadius;

        // Set angle
        displacement.X = Math.Cos(_wanderAngle) * displacement.Length;
        displacement.Y = Math.Sin(_wanderAngle) * displacement.Length;

        // Change wanderAngle just a bit, so it
        // won't have the same value in the next frame.
        _wanderAngle += _random.NextDouble() * angleChange - angleChange * 0.5;

        var wanderForce = circleCenter + displacement;

        return wanderForce;
    }
}