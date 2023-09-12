namespace CreatureSimulator.Simulator
{
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
            panel.Size = new Size(1000, 1000);
            panel.TabIndex = 0;
            panel.Paint += PaintGrid;
            // 
            // SimulatorWindow
            // 
            ClientSize = new Size(1230, 1059);
            Controls.Add(panel);
            Name = "SimulatorWindow";
            ResumeLayout(false);
        }

        private void PaintGrid(object? sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            var pen = new Pen(Color.Black, 1);

            using (Graphics g = e.Graphics)
            {
                for (int i = 0; i < 10; i++)
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

        private void SimulatorWindow_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}