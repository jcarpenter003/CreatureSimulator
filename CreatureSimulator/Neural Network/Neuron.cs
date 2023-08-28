namespace CreatureSimulator.NeuralNetwork
{
    public class Neuron
    {
        public string Name { get; set; } // For debug reasons

        public float SensorValue { get; set; } = 0.00f; // Value between 0 and 1
        public string Type { get; set; }
        public Neuron[] Connections { get; set; }
    }
}
