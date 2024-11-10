using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.Windowing.Glfw;
using SkiaSharp;

namespace MainApp;

internal sealed class FourmizApp : IDisposable
{
    private readonly IWindow _window;
    private readonly WindowOptions _options;
    private readonly Vector2D<double> _worldBoundaries;
    private GRGlInterface _grGlInterface = default!;
    private GRContext _grContext = default!;
    private GRBackendRenderTarget _renderTarget = default!;
    private SKSurface _surface = default!;
    private SKCanvas _canvas = default!;
    private World _world = default!;

    public FourmizApp(Vector2D<double> worldBoundaries)
    {
        GlfwWindowing.Use();

        _worldBoundaries = worldBoundaries;

        _options = WindowOptions.Default with
        {
            Title = "Fourmiz 2",
            Size = new Vector2D<int>((int)_worldBoundaries.X, (int)_worldBoundaries.Y),
            WindowBorder = WindowBorder.Fixed,
            WindowState = WindowState.Normal,
            PreferredStencilBufferBits = 8,
            PreferredBitDepth = new(8, 8, 8, 8)
        };
        _window = Window.Create(_options);
        _window.Load += OnLoad;
        _window.Render += OnRender;
        _window.Update += Update;
    }

    public void Run(World world)
    {
        _world = world;
        _window.Initialize();
    }

    private void OnLoad()
    {
        _grGlInterface = GRGlInterface.Create((name => _window.GLContext!.TryGetProcAddress(name, out var addr) ? addr : (IntPtr)0));
        _grContext = GRContext.CreateGl(_grGlInterface);

        _renderTarget = new GRBackendRenderTarget((int)_worldBoundaries.X, (int)_worldBoundaries.Y, 0, 8, new GRGlFramebufferInfo(0, 0x8058)); // 0x8058 = GL_RGBA8`
        _surface = SKSurface.Create(_grContext, _renderTarget, GRSurfaceOrigin.BottomLeft, SKColorType.Rgba8888);
        _canvas = _surface.Canvas;

        _window.Run();
    }

    private void OnRender(double elapsed)
    {
        _grContext.ResetContext();
        _canvas.Clear(SKColors.White);

        _world.Draw(_canvas, elapsed);

        _canvas.Flush();
    }

    private void Update(double elapsed)
    {
        _world.Update(elapsed);
    }

    public void Dispose()
    {
        _canvas.Dispose();
        _surface.Dispose();
        _renderTarget.Dispose();
        _grContext.Dispose();
        _grGlInterface.Dispose();

        _window.Dispose();
    }
}
