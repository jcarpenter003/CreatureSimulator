using CreatureSimulator.Creatures;
using CreatureSimulator.Network;
using System;

namespace CreatureSimulator.Simulator
{
    public class Simulation
    {
        public void Run()
        {
            //NeuralNetwork network = new NeuralNetwork();
            //network.NeuralNetworkTestDriver(10, 3, 3, 3);

           
            SimulatorWindow window = new SimulatorWindow();
            window.Show();

            Application.Run();
        }
    }
}