namespace CreatureSimulator.Simulator
{
    // This class contains helpful graphics methods
    public static class GraphicsExtensions
    {
        public static void DrawAndFillCircle(Graphics g, Pen pen, float centerX, float centerY, float radius)
        {
            DrawCircle(g, pen, centerX, centerY, radius);
            FillCircle(g, pen.Brush, centerX, centerY, radius);
        }

        public static void DrawCircle(Graphics g, Pen pen, float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX, centerY,
                      radius, radius);
        }

        public static void FillCircle(Graphics g, Brush brush,
                                  float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX, centerY,
                          radius, radius);
        }

        public static void FillRectangle(Graphics g, float x, float y, int height, int width)
        {
            Brush brush = new SolidBrush(Color.FromArgb(102, 41, 226, 100)); // 40% opacity green color
            Rectangle rect = new Rectangle(0, 0, 200, 1000);
            g.FillRectangle(brush, rect);
        }
    }
}
