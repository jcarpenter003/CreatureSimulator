using CreatureSimulator.Network;

namespace CreatureSimulator.Creatures
{
    public class Creature
    {
        public int Age { get; set; }
        public Genome Genome { get; set; } = new Genome();
        public NeuralNetwork NeuralNetwork { get; set; }
        public bool Gender { get; set; }
        public decimal OscillatorPeriod { get; set; }

        public Creature(NeuralNetwork neuralNetwork)
        {
            NeuralNetwork = neuralNetwork;
        }
    }
}
