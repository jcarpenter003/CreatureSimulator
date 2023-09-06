using CreatureSimulator.Enum;
using System.Text;

namespace CreatureSimulator.Network
{
    public class Neuron
    {
        #region Fields
        public string Name { get; set; } // For debug reasons
        public double SensorValue { get; set; } = 0.00; // Value between 0 and 1
        public NeuronType Type { get; set; }
        public CreatureAction Action { get; set; }
        public List<Neuron> Connections { get; set; } = new List<Neuron>();// TODO will need to contain weights towards connections
        #endregion

        #region Constructor
        public Neuron(string name, NeuronType type)
        {
            Name = name;
            Type = type;
        }
        #endregion

        #region To String Override for logging
        override
        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Neuron Name: {Name} - ");
            sb.Append($"Neuron Type: {Type.ToString()} - ");

            sb.Append("Neuron Sensor Value: ");
            sb.Append(String.Format("{0:0.##}", SensorValue));
            sb.Append(" - ");

            sb.Append($"Neuron Connections Total: {Connections.Count} - ");

            foreach (Neuron neuron in Connections)
            {
                sb.Append($"Neuron Connection: {neuron.Name} - ");
            }

            return sb.ToString();
        }
        #endregion
    }
}
