using Silk.NET.Maths;
using SkiaSharp;

namespace MainApp;

internal sealed class World
{
    private readonly List<Fourmiz> _fourmizs = [];
    private readonly List<FoodSpot> _foodSpots = [];

    public World(uint fourmizCount, uint foodSpotCount, Vector2D<double> worldBoundaries)
    {
        for (var i = 0; i < fourmizCount; i++)
        {
            _fourmizs.Add(new(new Vector2D<double>(Constants.Randomizer.Next((int)worldBoundaries.X), Constants.Randomizer.Next((int)worldBoundaries.Y / 2)), worldBoundaries));
        }

        for (var i = 0; i < foodSpotCount; i++)
        {
            _foodSpots.Add(new(new Vector2D<double>(Constants.Randomizer.Next((int)worldBoundaries.X), Constants.Randomizer.Next((int)worldBoundaries.Y / 2))));
        }
    }

    public void Update(double elapsed)
    {
        foreach (var fourmiz in _fourmizs)
        {
            fourmiz.Update(elapsed);
        }
    }

    public void Draw(SKCanvas canvas, double _)
    {
        foreach (var fourmiz in _fourmizs)
        {
            fourmiz.Draw(canvas);
        }

        foreach (var foodSpot in _foodSpots)
        {
            foodSpot.Draw(canvas);
        }
    }
}
