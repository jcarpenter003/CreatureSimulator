using CreatureSimulator.Network;

namespace CreatureSimulator.Simulator
{
    public class Simulation
    {
        public void Run()
        {
            NeuralNetwork network = new NeuralNetwork();
            network.NeuralNetworkTestDriver(5, 3, 3, 3);

            double input = 8;
            double input2 = 124;
            double input3 = 1;

            Console.WriteLine(Math.Tanh(input) * 0.5 + 0.5);
            Console.WriteLine(Math.Tanh(input2) * 0.5 + 0.5);
            Console.WriteLine(Math.Tanh(input3) * 0.5 + 0.5);

            Console.ReadLine();
        }
    }
}