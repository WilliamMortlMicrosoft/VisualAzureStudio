using System.Drawing;

namespace VisualAzureStudio
{
    internal static class Extensions
    {
        internal static Point OffsetPoint(this Point point, int dx, int dy)
        {
            return new Point(point.X + dx, point.Y + dy);
        }
    }
}
