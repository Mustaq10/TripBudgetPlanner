using Microsoft.Maui.Graphics;

namespace TripBudgetPlanner.Drawables;

public class PieChartDrawable : IDrawable
{
    public float Budget { get; set; }
    public float Expenses { get; set; }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.FillColor = Colors.LightGray;
        canvas.FillCircle((float)dirtyRect.Center.X, (float)dirtyRect.Center.Y, 80);

        float percent = (Expenses <= 0 || Budget <= 0)
            ? 0
            : Expenses / Budget;

        canvas.FillColor = Colors.Red;
        // Fix: Use the correct FillArc overload with 7 arguments
        canvas.FillArc(
            dirtyRect.Center.X - 80,
            dirtyRect.Center.Y - 80,
            160,
            160,
            0,
            percent * 360,
            true
        );
    }
}
