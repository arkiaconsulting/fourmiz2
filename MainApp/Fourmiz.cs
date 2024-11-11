using MainApp.FSM;
using Silk.NET.Maths;
using SkiaSharp;

namespace MainApp;

internal sealed class Fourmiz
{
    public double Energy => _energy;
    public StateMachine StateMachine => _stateMachine;

    private Vector2D<double> _position;
    private readonly Vector2D<double> _worldBoundaries;
    private Vector2D<double> _velocity = Some.RandomNormalizedVector / 1000;
    private readonly double _mass = double.Clamp(Constants.Randomizer.NextDouble() * Constants.MaxFourmizMass, Constants.MaxFourmizMass / 8, Constants.MaxFourmizMass);
    private readonly double _maxSpeed = double.Clamp(Constants.Randomizer.NextDouble() * Constants.MaxFourmizSpeed, Constants.MaxFourmizSpeed / 3, Constants.MaxFourmizSpeed);
    private double _wanderAngle = 0;
    private double _energy = 100;
    private Vector2D<double> _steering = Vector2D<double>.Zero;

    private readonly StateMachine _stateMachine;
    private SKPaint _color = Constants.Blue;

    public Fourmiz(Vector2D<double> initialPosition, Vector2D<double> worldBoundaries)
    {
        _position = initialPosition;
        _worldBoundaries = worldBoundaries;
        _stateMachine = new(new WanderState(this));
    }

    public void Update(double elapsed)
    {
        if (_stateMachine.CurrentState is DiedState)
        {
            return;
        }

        _steering = BoundariesRepulsion();

        _stateMachine.Update(elapsed);

        var acceleration = _steering / _mass;
        var dv = acceleration * elapsed;
        _velocity += dv;
        _velocity = _velocity.Truncate(_maxSpeed);
        _position += _velocity;
    }

    public void Draw(SKCanvas canvas)
    {
        canvas.DrawCircle((float)_position.X, (float)_position.Y, 10, _color);
    }

    public void ConsumeEnergy(double elapsed, double consumeRate)
    {
        _energy -= _velocity.Length * _mass * elapsed / consumeRate;
    }

    public void LookDead()
    {
        _velocity = Vector2D<double>.Zero;
        _color = Constants.Black;
    }

    public void Wander()
    {
        if (_velocity == Vector2D<double>.Zero)
        {
            return;
        }

        var circleDistance = 300;
        var circleRadius = 600;
        var angleChange = 90;

        // Calculate the circle center
        var circleCenter = Vector2D.Normalize(_velocity) * circleDistance;

        // Calculate the displacement force
        var displacement = new Vector2D<double>(0, -1) * circleRadius;

        // Set angle
        displacement.X = Math.Cos(_wanderAngle) * displacement.Length;
        displacement.Y = Math.Sin(_wanderAngle) * displacement.Length;

        // Change wanderAngle just a bit, so it
        // won't have the same value in the next frame.
        _wanderAngle += Constants.Randomizer.NextDouble() * angleChange - angleChange * 0.5;

        var wanderForce = circleCenter + displacement;

        _steering += wanderForce;
    }

    private Vector2D<double> BoundariesRepulsion()
    {
        var desired = Vector2D<double>.Zero;
        const double repulsionDistance = 30;

        var distanceToTop = _position.Y;
        // Either it's in repulsion distance, or it's outside the boundaries
        if (distanceToTop < repulsionDistance || distanceToTop < 0)
        {
            desired += new Vector2D<double>(0, 1 / Math.Abs(distanceToTop));
        }

        var distanceToBottom = _worldBoundaries.Y - _position.Y;
        // Either it's in repulsion distance, or it's outside the boundaries
        if (distanceToBottom < repulsionDistance || distanceToBottom < 0)
        {
            desired += new Vector2D<double>(0, -1 / Math.Abs(distanceToBottom));
        }

        var distanceToLeft = _position.X;
        // Either it's in repulsion distance, or it's outside the boundaries
        if (distanceToLeft < repulsionDistance || distanceToLeft < 0)
        {
            desired += new Vector2D<double>(1 / Math.Abs(distanceToLeft), 0);
        }

        var distanceToRight = _worldBoundaries.X - _position.X;
        // Either it's in repulsion distance, or it's outside the boundaries
        if (distanceToRight < repulsionDistance || distanceToRight < 0)
        {
            desired += new Vector2D<double>(-1 / Math.Abs(distanceToRight), 0);
        }

        if (desired == Vector2D<double>.Zero)
        {
            return Vector2D<double>.Zero;
        }

        return Vector2D.Normalize(desired) * _mass * 10;
    }
}