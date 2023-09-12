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
                Console.WriteLine(action.Key.ToString() + " " + action.Value); // Logging the raw values

                // First normalize the signal value to a value of between 0 and 1
                double normalizedValue = Math.Round((Math.Tanh(action.Value) * 0.5 + 0.5), 2);
                Console.WriteLine(action.Key.ToString() + " -- NormalizedValue:" + normalizedValue);

                // Then pass the normalized signal value into a function which determines probability of the action executing based off of the value and returns true or false if execute or not
                bool executeAction = ProbabilisticTrue(normalizedValue);
                Console.WriteLine("Action Will Be Executed? " + executeAction);

                Console.WriteLine("------------ \n");

                // Finally Execute the action
            }
        }

        public bool ProbabilisticTrue(double factor) // Factor must be between 0 and 1
        {
            Debug.Assert(factor <= 1);

            var rand = new Random(); // TODO move this to a location where it's only initialized once, or once per thread
            var randNum = (rand.NextDouble() * (10 - 1) + 1) / 10;
            var rounded = Math.Round(randNum, 2);

            //Console.WriteLine($"Factor: {factor} - - - Rand Num: {rounded}"); // Log Statement

            return rounded < factor;
        }
    }
}