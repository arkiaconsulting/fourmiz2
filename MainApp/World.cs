using Silk.NET.Maths;
using SkiaSharp;

namespace MainApp;

internal sealed class World
{
    public FoodSpot[] FoodSpots => _foodSpots.ToArray();

    private readonly List<Fourmiz> _fourmizs = [];
    private readonly List<FoodSpot> _foodSpots = [];

    public World(uint fourmizCount, uint foodSpotCount, Vector2D<double> worldBoundaries)
    {
        for (var i = 0; i < fourmizCount; i++)
        {
            _fourmizs.Add(new(new Vector2D<double>(Constants.Randomizer.Next((int)worldBoundaries.X), Constants.Randomizer.Next((int)worldBoundaries.Y)), worldBoundaries, this));
        }

        for (var i = 0; i < foodSpotCount; i++)
        {
            _foodSpots.Add(new(new Vector2D<double>(
                Constants.Randomizer.Next((int)FoodSpot.Size, (int)worldBoundaries.X - (int)FoodSpot.Size),
                Constants.Randomizer.Next((int)FoodSpot.Size, (int)worldBoundaries.Y - (int)FoodSpot.Size))
            ));
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
        foreach (var foodSpot in _foodSpots)
        {
            foodSpot.Draw(canvas);
        }

        foreach (var fourmiz in _fourmizs)
        {
            fourmiz.Draw(canvas);
        }
    }
}
