using NeuralNetworkInformation.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkInformation
{
    public class Neuron
    {
        #region Fields
        public string Name { get; set; }
        public double SensorValue { get; set; } = 0.00;
        public NeuronType Type { get; set; }
        public SensorType SensorType { get; set; }
        public CreatureAction CreatureAction { get; set; }
        public List<Neuron> Connections { get; set; }
        #endregion

        #region Constructor
        public Neuron(string name, NeuronType type)
        {
            this.Name = name;
            this.Type = type;
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
