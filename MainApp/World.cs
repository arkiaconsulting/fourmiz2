using SkiaSharp;

namespace MainApp;

internal sealed class World
{
    private readonly List<Fourmiz> _fourmizs = [];

    public World(uint fourmizCount, SKPoint worldBoundaries)
    {
        for (var i = 0; i < fourmizCount; i++)
        {

            _fourmizs.Add(new(new SKPoint(Random.Shared.Next((int)worldBoundaries.X), Random.Shared.Next((int)worldBoundaries.Y / 2)), worldBoundaries));
        }
    }

    public void Update(double elapsed)
    {
        foreach (var fourmiz in _fourmizs)
        {
            fourmiz.Update(elapsed);
        }
    }

    public void Draw(SKCanvas canvas, double elapsed)
    {
        foreach (var fourmiz in _fourmizs)
        {
            fourmiz.Draw(canvas);
        }
    }
}
