using CreatureSimulator.Simulator;

namespace CreatureSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var simulation = new Simulation();
            simulation.Run();
        }
    }
}