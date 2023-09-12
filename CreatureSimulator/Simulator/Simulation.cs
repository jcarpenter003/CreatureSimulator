namespace CreatureSimulator.Simulator
{
    public class Simulation
    {
        private int[,] simulationGrid = new int[10, 10];

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