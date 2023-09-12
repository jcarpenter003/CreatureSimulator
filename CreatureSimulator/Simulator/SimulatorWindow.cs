using System.Windows.Forms;
using System.Windows;
using System.Reflection.Metadata;

namespace CreatureSimulator.Simulator
{
    public partial class SimulatorWindow : Form
    {
        private Panel panel;

        public SimulatorWindow()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.FormClosing += new FormClosingEventHandler(SimulatorWindow_FormClosing);
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
            panel.Size = new Size(285, 264);
            panel.TabIndex = 0;
            // 
            // SimulatorWindow
            // 
            ClientSize = new Size(284, 261);
            Controls.Add(panel);
            Name = "SimulatorWindow";
            ResumeLayout(false);
        }

        private void SimulatorWindow_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}