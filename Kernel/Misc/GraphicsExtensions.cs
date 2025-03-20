using System;

namespace MOOS.Misc
{
    public static class GraphicsExtensions
    {
        public static void DrawRotatedFilledRect(int cx, int cy, int w, int h, float angle, uint color)
        {
            float radians = angle * (float)(Math.PI / 180.0);

            // Calculate the four corners of the rectangle before rotation
            int x1 = cx - w / 2, y1 = cy - h / 2;
            int x2 = cx + w / 2, y2 = cy - h / 2;
            int x3 = cx + w / 2, y3 = cy + h / 2;
            int x4 = cx - w / 2, y4 = cy + h / 2;

            // Apply rotation
            (int rx1, int ry1) = RotatePoint(x1, y1, cx, cy, radians);
            (int rx2, int ry2) = RotatePoint(x2, y2, cx, cy, radians);
            (int rx3, int ry3) = RotatePoint(x3, y3, cx, cy, radians);
            (int rx4, int ry4) = RotatePoint(x4, y4, cx, cy, radians);

            // Draw the filled rotated rectangle
            DrawFilledQuad(rx1, ry1, rx2, ry2, rx3, ry3, rx4, ry4, color);
        }

        private static (int, int) RotatePoint(int x, int y, int cx, int cy, float angle)
        {
            float cosA = (float)Math.Cos(angle);
            float sinA = (float)Math.Sin(angle);

            int nx = (int)(cx + (x - cx) * cosA - (y - cy) * sinA);
            int ny = (int)(cy + (x - cx) * sinA + (y - cy) * cosA);

            return (nx, ny);
        }

        private static void DrawFilledQuad(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, uint color)
        {
            // Use scanline algorithm to fill the polygon
            Framebuffer.Graphics.FillTriangle(x1, y1, x2, y2, x3, y3, color);
            Framebuffer.Graphics.FillTriangle(x1, y1, x3, y3, x4, y4, color);
        }
    }
}
