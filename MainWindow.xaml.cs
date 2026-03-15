using Gigasoft.ProEssentials;
using Gigasoft.ProEssentials.Enums;
using System.Windows;
using System.Windows.Media;

namespace ProEssentialsWpfQuickstart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Random Rand_Num = new Random(unchecked((int)DateTime.Now.Ticks));

        public MainWindow()
        {
            InitializeComponent();
            Pesgo1.Loaded += new RoutedEventHandler(Pesgo1_Loaded);
        }

        // control_Loaded Event 
        void Pesgo1_Loaded(object sender, RoutedEventArgs e)
        {
            Pesgo1.PeFont.SizeGlobalCntl = 1.1F;

            //100  *** Simple Scientific Graph ***

            //! Right button click to show popup menu. //
            //! Double Click to show customization dialog. //
            //! Left-Click and drag to draw zoom box. Use popup memu or 'z' to undo zoom. //

            // Simple example show the basics of a scientific graph object. //
            // Scientific Graph's contain both YData and XData and thus data
            // is not plotted equally spaced as the graph object does.

            // RenderSizeXdpi is unique to WPF interfaces. 
            // Default is true, results in sharpest lines all the time. 
            // Setting false and running on system without 100% TextSize (i.e. 125% or 150% text size) will result in fuzzier lines and text
            // as everything will be scaled larger.  Some may prefer the slight fuzziness of fully scaled results but we prefer the sharper images. 
            // Pesgo1.RenderSizeXdpi = true;

            Pesgo1.PeUserInterface.Cursor.PromptTracking = true;
            Pesgo1.PeUserInterface.Cursor.PromptLocation = CursorPromptLocation.ToolTip;
            Pesgo1.PeUserInterface.Cursor.PromptStyle = CursorPromptStyle.XYValues;

            // Enable Bar Glass Effect //
            Pesgo1.PePlot.Option.BarGlassEffect = true;

            // Enable Plotting style gradient and bevel features //
            Pesgo1.PePlot.Option.AreaGradientStyle = PlotGradientStyle.VerticalAscentInverse;
            Pesgo1.PePlot.Option.AreaBevelStyle = BevelStyle.MediumSmooth;
            Pesgo1.PePlot.Option.SplineGradientStyle = PlotGradientStyle.VerticalAscentInverse;
            Pesgo1.PePlot.Option.SplineBevelStyle = SplineBevelStyle.MediumSmooth;

            Pesgo1.PePlot.Option.PointGradientStyle = PlotGradientStyle.VerticalAscentInverse;
            Pesgo1.PeColor.PointBorderColor = Color.FromArgb(100, 0, 0, 0);
            Pesgo1.PePlot.Option.LineSymbolThickness = 3;
            Pesgo1.PePlot.Option.AreaBorder = 1;

            // Prepare images in memory //
            Pesgo1.PeConfigure.PrepareImages = true;

            // Pass Data //
            Pesgo1.PeData.Subsets = 4;
            Pesgo1.PeData.Points = 120;

            for (int s = 0; s <= 3; s++)
            {
                int nOffset = (int)(Rand_Num.NextDouble() * 250);
                for (int p = 0; p <= 119; p++)
                {
                    Pesgo1.PeData.X[s, p] = (float)((p + 1) * 100.0F);
                    Pesgo1.PeData.Y[s, p] = (float)((p + 1) * 1 + (Rand_Num.NextDouble() * 250)) + (float)(Math.Sin(((double)(nOffset + p)) * .03F) * 700.0F) - ((s * 140.0F));
                }
            }

            // Set DataShadows to show 3D //
            Pesgo1.PePlot.DataShadows = DataShadows.Shadows;

            Pesgo1.PeUserInterface.Allow.FocalRect = false;
            Pesgo1.PePlot.Method = SGraphPlottingMethod.PointsPlusSpline;
            Pesgo1.PeGrid.LineControl = GridLineControl.Both;
            Pesgo1.PeGrid.Style = GridStyle.Dot;
            Pesgo1.PeUserInterface.Allow.Zooming = AllowZooming.HorzAndVert;
            Pesgo1.PeUserInterface.Allow.ZoomStyle = ZoomStyle.Ro2Not;

            // Enable middle mouse dragging //
            Pesgo1.PeUserInterface.Scrollbar.MouseDraggingX = true;
            Pesgo1.PeUserInterface.Scrollbar.MouseDraggingY = true;

            Pesgo1.PeString.MainTitle = "Test Results";
            Pesgo1.PeString.SubTitle = "";
            Pesgo1.PeString.YAxisLabel = "Performance";
            Pesgo1.PeString.XAxisLabel = "Duration";

            // subset labels //
            Pesgo1.PeString.SubsetLabels[0] = "Horsepower";
            Pesgo1.PeString.SubsetLabels[1] = "Torque";
            Pesgo1.PeString.SubsetLabels[2] = "Temperature";
            Pesgo1.PeString.SubsetLabels[3] = "Pressure";

            // subset colors //
            Pesgo1.PeColor.SubsetColors[0] = Color.FromArgb(255, 213, 0, 69);
            Pesgo1.PeColor.SubsetColors[1] = Color.FromArgb(255, 63, 200, 0);
            Pesgo1.PeColor.SubsetColors[2] = Color.FromArgb(255, 212, 168, 0);
            Pesgo1.PeColor.SubsetColors[3] = Color.FromArgb(255, 169, 0, 153);

            // subset line types
            Pesgo1.PeLegend.SubsetLineTypes[0] = LineType.MediumSolid;
            Pesgo1.PeLegend.SubsetLineTypes[1] = LineType.MediumSolid;
            Pesgo1.PeLegend.SubsetLineTypes[2] = LineType.MediumSolid;
            Pesgo1.PeLegend.SubsetLineTypes[3] = LineType.MediumSolid;

            // subset point types
            Pesgo1.PeLegend.SubsetPointTypes[0] = PointType.DotSolid;
            Pesgo1.PeLegend.SubsetPointTypes[1] = PointType.UpTriangleSolid;
            Pesgo1.PeLegend.SubsetPointTypes[2] = PointType.SquareSolid;
            Pesgo1.PeLegend.SubsetPointTypes[3] = PointType.DownTriangleSolid;
            Pesgo1.PeLegend.SubsetPointTypes[4] = PointType.DotSolid;
            Pesgo1.PeLegend.SubsetPointTypes[5] = PointType.SquareSolid;
            Pesgo1.PeLegend.SubsetPointTypes[6] = PointType.DiamondSolid;
            Pesgo1.PeLegend.SubsetPointTypes[7] = PointType.UpTriangleSolid;

            Pesgo1.PeLegend.SimplePoint = true;
            Pesgo1.PeLegend.SimpleLine = true;
            Pesgo1.PeLegend.Style = LegendStyle.OneLine;
            Pesgo1.PeGrid.Option.MultiAxisStyle = MultiAxisStyle.SeparateAxes;

            Pesgo1.PePlot.Option.GradientBars = 8;
            Pesgo1.PeConfigure.TextShadows = TextShadows.BoldText;
            Pesgo1.PeFont.MainTitle.Bold = true;
            Pesgo1.PeFont.SubTitle.Bold = true;
            Pesgo1.PeFont.Label.Bold = true;
            Pesgo1.PePlot.Option.LineShadows = true;
            Pesgo1.PeFont.FontSize = Gigasoft.ProEssentials.Enums.FontSize.Large;
            Pesgo1.PeUserInterface.Scrollbar.ScrollingHorzZoom = true;
            Pesgo1.PeData.Precision = DataPrecision.OneDecimal;

            // Various other features //
            Pesgo1.PeFont.Fixed = true;
            Pesgo1.PeColor.BitmapGradientMode = false;
            Pesgo1.PeColor.QuickStyle = QuickStyle.DarkNoBorder;

            Pesgo1.PeGrid.Configure.AutoMinMaxPadding = 1;

            Pesgo1.PeConfigure.ImageAdjustLeft = 20;
            Pesgo1.PeConfigure.ImageAdjustRight = 20;
            Pesgo1.PeConfigure.ImageAdjustTop = 10;

            // Set various export defaults //
            Pesgo1.PeSpecial.DpiX = 600;
            Pesgo1.PeSpecial.DpiY = 600;

            // default export setting //
            Pesgo1.PeUserInterface.Dialog.ExportSizeDef = ExportSizeDef.NoSizeOrPixel;
            Pesgo1.PeUserInterface.Dialog.ExportTypeDef = ExportTypeDef.Png;
            Pesgo1.PeUserInterface.Dialog.ExportDestDef = ExportDestDef.Clipboard;
            Pesgo1.PeUserInterface.Dialog.ExportUnitXDef = "1280";
            Pesgo1.PeUserInterface.Dialog.ExportUnitYDef = "768";
            Pesgo1.PeUserInterface.Dialog.ExportImageDpi = 300;

            Pesgo1.PeConfigure.RenderEngine = RenderEngine.Direct2D;
            Pesgo1.PeConfigure.AntiAliasGraphics = true;
            Pesgo1.PeConfigure.AntiAliasText = true;

            // Call ReinitializeResetImage at end **'
            Pesgo1.PeFunction.ReinitializeResetImage();
            Pesgo1.Invalidate();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Do not use this event to initialize ProEssentials controls, control creation is not 100% complete, use the Pego_Loaded event, as above. // 

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

    }
}



