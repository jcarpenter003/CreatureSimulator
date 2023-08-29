using CreatureSimulator.Network;

namespace CreatureSimulator.Simulator
{
    public class Simulation
    {
        public void Run()
        {
            NeuralNetwork network = new NeuralNetwork();
            network.NeuralNetworkTestDriver(5, 3, 3, 3);
            Console.ReadLine();
        }
    }
}