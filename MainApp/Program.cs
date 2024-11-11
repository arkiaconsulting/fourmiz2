﻿using MainApp;
using Silk.NET.Maths;

var boundaries = new Vector2D<double>(1024, 768);
using var fourmiz = new FourmizApp(boundaries);
var world = new World(1, boundaries);

fourmiz.Run(world);
