# ProEssentials WPF Quickstart — Simple Scientific Graph

A minimal, fully working WPF .NET 8 example demonstrating the **Pesgo** (Scientific Graph Object) from [Gigasoft ProEssentials](https://gigasoft.com). Clone, build, run — no configuration required.

![Simple Scientific Graph](https://gigasoft.com/wpf-chart/screenshots/screen100.png)

---

## What This Example Shows

This is a self-contained WPF implementation of **Example 100 — Simple Scientific Graph**, the foundational Pesgo example in the ProEssentials library. The full example suite, including C#, C++ MFC, and VBA versions, is available at:

➡️ [gigasoft.com/examples/100](https://gigasoft.com/examples/100)

Example 100 is the base that many subsequent ProEssentials examples build upon — other examples in the suite introduce their feature and show only the difference from this starting point.

---

## What You'll See

- 4 subsets (Horsepower, Torque, Temperature, Pressure) × 120 points each
- Continuous XY data — X axis values at 100, 200, 300... intervals
- Spline plus point plotting with gradient and bevel effects
- Dark theme via `QuickStyle.DarkNoBorder`
- Direct2D GPU rendering with anti-aliasing
- Hover tooltip showing XY values
- Left-click drag to zoom, right-click for full context menu
- Built-in export, print, and customization dialog

---

## Prerequisites

- Visual Studio 2022
- .NET 8 SDK
- Internet connection for NuGet restore

---

## How to Run
```
1. Clone this repository
2. Open ProEssentialsWpfQuickstart.sln in Visual Studio 2022
3. Build → Rebuild Solution  (restores NuGet package automatically)
4. Press F5
```

Right-click anywhere on the chart to explore the built-in context menu — export, print, zoom reset, and full property customization are all built in.

---

## Key Concepts in the Code

**Pesgo vs Pego** — Pesgo is the Scientific Graph Object. Unlike Pego which assumes equally-spaced X values, Pesgo requires explicit `PeData.X[s,p]` values alongside `PeData.Y[s,p]`. Use Pesgo for scientific, engineering, and any data where X spacing is irregular or meaningful.

**Control Loaded event** — ProEssentials initialization must happen in the control's own `Loaded` event (`Pesgo1_Loaded`), not the window's `Window_Loaded` event. The window loaded event fires before the control is fully initialized.

**ReinitializeResetImage()** — always the last call after setting properties. Triggers the full data-to-image render pipeline.

---

## NuGet Package

This project references [`ProEssentials.Chart.Net80.x64.Wpf`](https://www.nuget.org/packages/ProEssentials.Chart.Net80.x64.Wpf) from nuget.org. Package restore happens automatically on build.

---

## More Examples

The full ProEssentials example suite with 116 examples across C#, C++ MFC, and VBA is included with the evaluation download:

⬇️ [No-hassle evaluation download](https://gigasoft.com/net-chart-component-wpf-winforms-download)
📖 [Developer Guide](https://gigasoft.com/developer-guide)
🔍 [API Explorer](https://gigasoft.com/documentation)
🌐 [gigasoft.com](https://gigasoft.com)

---

## License

Example code is MIT licensed. ProEssentials requires a commercial license for continued use.