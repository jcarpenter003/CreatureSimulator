using CreatureSimulator.Config;
using CreatureSimulator.Creatures;
using System.Drawing;

namespace CreatureSimulator.Simulator
{
    //TODO NEED TO CLEAN UP GRAPHICS INITIALIZATION/USAGE
    //TODO NEED TO FIGURE OUT HOW GRAPHICS WORK..

    public partial class SimulatorWindow : Form
    {
        private Panel panel;

        public SimulatorWindow()
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;

            this.FormClosing += new FormClosingEventHandler(SimulatorWindow_FormClosing);

            InitializeComponent();
            this.CenterToScreen();
        }

        private void InitializeComponent()
        {
            panel = new Panel();
            SuspendLayout();
            // 
            // panel
            // 
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.Fixed3D;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(1010, 1010);
            panel.TabIndex = 0;
            panel.Paint += PaintGridEventHandler;
            // 
            // SimulatorWindow
            // 
            ClientSize = new Size(1230, 1059);
            Controls.Add(panel);
            Name = "SimulatorWindow";
            ResumeLayout(false);
        }

        private void PaintGridEventHandler(object? sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            var pen = new Pen(Color.Black, 1);

            using (Graphics g = e.Graphics)
            {
                for (int i = 0; i <= 10; i++)
                {
                    // Draws Columns
                    var point1 = new Point(i * 100, 0);
                    var point2 = new Point(i * 100, 1000);
                    g.DrawLine(pen, point1, point2);

                    // Draws Rows
                    var rowPoint1 = new Point(0, i * 100);
                    var rowPoint2 = new Point(1000, i * 100);
                    g.DrawLine(pen, rowPoint1, rowPoint2);
                }
            }
        }

        private void PaintGrid(Graphics g)
        {
            var pen = new Pen(Color.Black, 1);

            for (int i = 0; i <= 10; i++)
            {
                // Draws Columns
                var point1 = new Point(i * 100, 0);
                var point2 = new Point(i * 100, 1000);
                g.DrawLine(pen, point1, point2);

                // Draws Rows
                var rowPoint1 = new Point(0, i * 100);
                var rowPoint2 = new Point(1000, i * 100);
                g.DrawLine(pen, rowPoint1, rowPoint2);
            }
        }

        public void ClearPanel()
        {
            using (Graphics g = panel.CreateGraphics())
            {
                g.Clear(Color.White);
                this.PaintSafeArea(0, 0, 1000, 200);
                //PaintGrid(g);
            }
        }

        public void PaintCreature(Creature creature)
        {
            using (Graphics g = panel.CreateGraphics())
            {

                var creaturePen = new Pen(Color.Orange, 1);
                GraphicsExtensions.DrawAndFillCircle(g, creaturePen, creature.creatureXLocation, creature.creatureYLocation, GlobalConfig.CreatureRadiusSize);
            }
        }

        #region Function To Paint Safe Area On Screen
        public void PaintSafeArea(float x, float y, int height, int width)
        {
            using (Graphics g = panel.CreateGraphics())
            {
                GraphicsExtensions.FillRectangle(g, x, y, height, width);
            }
        }
        #endregion

        public bool IsPointSafe(int x, int y)
        {
            Rectangle rect = new Rectangle(0, 0, 200, 1000);
            return !rect.Contains(x, y);
        }

        #region Function to kill main thread when form closed
        private void SimulatorWindow_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}