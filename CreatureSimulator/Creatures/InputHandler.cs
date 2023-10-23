using CreatureSimulator.Enum;
using CreatureSimulator.Network;

namespace CreatureSimulator.Creatures
{
    public class InputHandler
    {
        public void HandleInputLayer(Creature creature)
        {
            foreach (Neuron n in creature.NeuralNetwork.InputLayer)
            {
                switch (n.SensorType)
                {
                    case (SensorType.SENSE_FORWARD):
                        break;
                    case (SensorType.SENSE_BACKWARD):
                        break;
                    case (SensorType.SENSE_LEFT):
                        break;
                    case (SensorType.SENSE_RIGHT):
                        break;
                }
            }
        }
    }
}
