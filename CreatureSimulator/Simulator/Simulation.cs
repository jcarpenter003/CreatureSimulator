using CreatureSimulator.Config;
using CreatureSimulator.Creatures;
using CreatureSimulator.Network;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CreatureSimulator.Simulator
{
    public class Simulation
    {
        private int[,] simulationGrid = new int[GlobalConfig.MapSizeX, GlobalConfig.MapSizeY];
        private readonly SimulatorWindow _window;
        private List<Creature> _creatures;

        #region Constructor
        public Simulation()
        {
            _window = new SimulatorWindow();
            _creatures = new List<Creature>();
        }
        #endregion

        public void Run()
        {
            _window.Show();

            // Initial Paint of creatures on map
            for (int i = 0; i < 10; i++)
            {
                NeuralNetwork network = new NeuralNetwork();
                network.InitRandomNeuralNetwork(3, 4, 5, 5);

                var creature = new Creature(network);

                _creatures.Add(creature);
                _window.PaintCreature(creature);
            }


            Thread movementThread = new Thread( () => { RunMovement(); });
            movementThread.IsBackground = true;
            movementThread.Start();

            Application.Run(_window);
        }

        public void RunMovement()
        {
            //Movement Loop
            while (true)
            {
                _window.ClearPanel();
                foreach (Creature creature in _creatures)
                {
                    creature.NeuralNetwork.FeedForward(); // Feed that shizz
                    creature.ExecuteActions(); // Execute that shizznips
                    _window.PaintCreature(creature);
                }

                Thread.Sleep(500); // This adjusts the speed of the simulation
            }
        }
    }
}