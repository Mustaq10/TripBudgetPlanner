using Microsoft.Maui.Graphics;

namespace TripBudgetPlanner.Drawables;

public class PieCategoryChartDrawable : IDrawable
{
    public Dictionary<string, double> CategoryValues { get; set; } = new();
    public Dictionary<string, Color> CategoryColors { get; set; } = new();

    public void Draw(ICanvas canvas, RectF rect)
    {
        if (CategoryValues == null || CategoryValues.Count == 0)
            return;

        double total = CategoryValues.Values.Sum();
        if (total <= 0)
            return;

        float centerX = rect.Center.X;
        float centerY = rect.Center.Y;
        float radius = Math.Min(rect.Width, rect.Height) / 2 - 10;

        float startAngle = 0f;

        foreach (var item in CategoryValues)
        {
            string category = item.Key;
            double value = item.Value;

            float sweep = (float)((value / total) * 360f);

            canvas.SaveState();
            canvas.FillColor = CategoryColors[category];

            canvas.FillArc(centerX - radius,
                           centerY - radius,
                           radius * 2,
                           radius * 2,
                           startAngle,
                           sweep,
                           true);

            canvas.RestoreState();

            startAngle += sweep;
        }
    }
}
