using CreatureSimulator.Network;

namespace CreatureSimulator.Simulator
{
    public class Simulation
    {
        public void Run()
        {
            NeuralNetwork network = new NeuralNetwork();
            network.NeuralNetworkTestDriver(3, 3, 1, 5);
            Console.ReadLine();
        }
    }
}