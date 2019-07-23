using System;
using System.Drawing;
using System.Linq;
using VisualAzureStudio.Models;
using VisualAzureStudio.Models.Connections;

namespace VisualAzureStudio
{
    internal static class Extensions
    {
        internal static Point OffsetPoint(this Point point, int dx, int dy)
        {
            return new Point(point.X + dx, point.Y + dy);
        }

        internal static ConnectionBase FindByPoint(this Design design, Point point, int lineWidth)
        {
            if (design?.Connections == null) {
                return null;
            }

            int lineWidthOffset = lineWidth / 2;

            foreach (ConnectionBase connection in design.Connections) {
                Point corner = new Point(connection.End.X, connection.Start.Y);

                // test first segment (horizontal)

                int top = connection.Start.Y - lineWidthOffset;
                int bottom = top + lineWidth;
                int left = Math.Min(connection.Start.X, connection.End.X) - lineWidthOffset;
                int right = Math.Max(connection.Start.X, connection.End.X) + lineWidthOffset;

                if (top <= point.Y && bottom >= point.Y && left <= point.X && right >= point.X) {
                    return connection;
                }

                // test second segment (vertical)

                top = Math.Min(connection.Start.Y, connection.End.Y) - lineWidthOffset;
                bottom = Math.Max(connection.Start.Y, connection.End.Y) + lineWidthOffset;
                left = connection.End.X - lineWidthOffset;
                right = left + lineWidth;

                if (top <= point.Y && bottom >= point.Y && left <= point.X && right >= point.X) {
                    return connection;
                }
            }

            return null;
        }

        /// <summary>
        /// Calculates and sets the locations of the connection coordinates in the design.
        /// </summary>
        /// <param name="design">Design containing the connection coordinates to calculate.</param>
        internal static void CalculateLines(this Design design)
        {
            foreach (ConnectionBase connection in design.Connections) {
                connection.Start = design.Components.First(c => c.Id == connection.Item1Id).Location.OffsetPoint(75, 34);
                connection.End = design.Components.First(c => c.Id == connection.Item2Id).Location.OffsetPoint(75, 34);
            }
        }

        /// <summary>
        /// Draws the connection lines of the given design to to the given graphics object.
        /// </summary>
        /// <param name="design">Design containing the connections to draw.</param>
        /// <param name="graphics">Graphics object to draw the lines on.</param>
        internal static void DrawLines(this Design design, Graphics graphics)
        {
            Pen pen = new Pen(Color.Silver, 5);

            foreach (ConnectionBase connection in design.Connections) {
                graphics.DrawLines(pen, new[] { connection.Start, new Point(connection.End.X, connection.Start.Y), connection.End });
            }
        }
    }
}
