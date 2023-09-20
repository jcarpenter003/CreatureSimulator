using CreatureSimulator.Creatures;
using CreatureSimulator.Network;

namespace CreatureSimulator.Simulator
{
    public class Simulation
    {
        private int[,] simulationGrid = new int[10, 10];

        public void Run()
        {
            SimulatorWindow window = new SimulatorWindow();
            window.Show();

            var creatures = new List<Creature>();

            // Initial Paint of creatures on map
            for (int i = 0; i < 10; i++)
            {
                NeuralNetwork network = new NeuralNetwork();
                network.InitRandomNeuralNetwork(3, 4, 5, 5);

                var creature = new Creature(network);

                creatures.Add(creature);
                window.PaintCreature(creature);
            }

            //Application.Run(window);

            //Movement Loop
            while (true)
            {
                window.ClearPanel();
                foreach (Creature creature in creatures)
                {
                    creature.NeuralNetwork.FeedForward(); // Feed that shizz
                    creature.ExecuteActions(); // Execute that shizznips
                    window.PaintCreature(creature);
                }

                Thread.Sleep(500); // This adjusts the speed of the simulation
            }
        }
    }
}