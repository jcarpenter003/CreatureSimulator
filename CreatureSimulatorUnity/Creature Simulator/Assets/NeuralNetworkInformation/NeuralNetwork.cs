using NeuralNetworkInformation.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkInformation
{
    public class NeuralNetwork
    {
        #region Fields
        public List<Neuron> InputLayer { get; set; } = new List<Neuron>();
        public List<Neuron> InternalLayer { get; set; } = new List<Neuron>();
        public List<Neuron> OutputLayer { get; set; } = new List<Neuron>();
        //private ActionHandler ActionHandler { get; set; } = new ActionHandler(); todo
        #endregion



        #region Drive Values Forward Through The Network
        public void FeedForward()
        {
            // Take each Neuron in the input layer and feed it's value forward to the internal layer -> repeat with internal layer into output layer
            // TODO apply scaling function to normalize values between 0-1

            foreach (Neuron neuron in InputLayer)
            {
                foreach (Neuron connection in neuron.Connections)
                {
                    connection.SensorValue += neuron.SensorValue;
                }
            }

            foreach (Neuron neuron in InternalLayer)
            {
                foreach (Neuron connection in neuron.Connections)
                {
                    connection.SensorValue += neuron.SensorValue;
                }
            }

            //ActionHandler.ExecuteActions(MapNeuronsToActions(OutputLayer), new Creature(this)); // TODO for now we're passing a new creature into the action handler. Action handler won't be called here in final version of project

            //LogToConsole();
        }
        #endregion

        // Init Neural Network with randomly assigned connections
        // TODO RIGHT NOW THIS METHOD GENERATES RANDOM SENSOR VALUES AS WELL
        public NeuralNetwork InitRandomNeuralNetwork(int inputNeurons, int internalNeurons, int outputNerons, int maxConnections)
        {
            var rand = new Random();

            // Create Input Neurons With Sensor Values
            for (int i = 0; i < inputNeurons; i++)
            {
                var neuron = new Neuron($"Input Neuron {i}", NeuronType.Input);
                neuron.SensorValue = rand.NextDouble();
                InputLayer.Add(neuron);
            }

            // Create Internal Neurons
            for (int i = 0; i < internalNeurons; i++)
            {
                var neuron = new Neuron($"Internal Neuron {i}", NeuronType.Internal);
                InternalLayer.Add(neuron);
            }

            // Connect Input Layer to Internal Layer Randomly
            for (int i = 0; i < inputNeurons; i++)
            {
                int numOfConnections = rand.Next(maxConnections); // 0 connects up to max configged number

                for (int j = 0; j < numOfConnections; j++)
                {
                    int selectedInternalNeuron = rand.Next(InternalLayer.Count);
                    InputLayer[i].Connections.Add(InternalLayer[selectedInternalNeuron]);
                }
            }

            // Create Output Neurons
            for (int i = 0; i < outputNerons; i++)
            {
                var neuron = new Neuron($"Output Neuron {i}", NeuronType.Output);

                // Randomly assign an action to output layer neurons
                int selectedAction = rand.Next(0, 4);
                neuron.CreatureAction = (CreatureAction)selectedAction;

                OutputLayer.Add(neuron);
            }

            // Connect Internal Layer to Output Layer Randomly
            for (int i = 0; i < internalNeurons; i++)
            {
                int numOfConnections = rand.Next(maxConnections); // 0 connects up to max configged number

                for (int j = 0; j < numOfConnections; j++)
                {
                    int selectedOutputNeuron = rand.Next(OutputLayer.Count);
                    InternalLayer[i].Connections.Add(OutputLayer[selectedOutputNeuron]);
                }
            }

            return this;
        }
    }
}
