using CreatureSimulator.Enum;
using System.Diagnostics;

namespace CreatureSimulator.Creatures
{
    public class ActionHandler
    {
        /*
         * The 'actions' dictionary contains a list of the creatures actions and a double value representing how driven the action is
         * 
         * This method will loop through the actions and normalize the driven value to a range of 0-1 
         * this normalized value will be passed through a probability function to determine the probability of the action being executed
         * the actions that get executed will be put into a queue to be activated later
         * nb 
         e`y */
        public void ExecuteActions(IDictionary<CreatureAction, double> actions, Creature creature)
        {
            foreach (KeyValuePair<CreatureAction, double> action in actions)
            {
                // First normalize the signal value to a value of between 0 and 1

                // Then pass the normalized signal value into a function which determines probability of the action executing based off of the value and returns true or false if execute or not

                // Finally Execute the action
            }
        }

        // TODO Test this function
        public bool ProbabilisticTrue(double factor) // Factor must be between 0 and 1
        {
            Debug.Assert(factor <= 1);

            var rand = new Random();
            return (rand.Next(1,11) / 10) < factor; // Allegedly this will produce a random number between 1 and 10, then divide by 10. So 10 becomes 1, 9 becomes 0.9 and so on. If this value is less than the incoming factor we return true.
        }
    }
}