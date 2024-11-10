using MainApp;
using SkiaSharp;

var boundaries = new SKPoint(1024, 768);
using var fourmiz = new FourmizApp(boundaries);
var world = new World(1, boundaries);

fourmiz.Run(world);
