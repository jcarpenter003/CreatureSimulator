using CreatureSimulator.Enum;
using CreatureSimulator.Network;
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
            var actionsToExecute = new Dictionary<CreatureAction, double>();

            foreach (KeyValuePair<CreatureAction, double> action in actions)
            {
                Console.WriteLine(action.Key.ToString() + " " + action.Value); // Logging the raw values

                // First normalize the signal value to a value of between 0 and 1
                double normalizedValue = Math.Round((Math.Tanh(action.Value) * 0.5 + 0.5), 2);

                // Then pass the normalized signal value into a function which determines probability of the action executing based off of the value and returns true or false if execute or not
                bool executeAction = ProbabilisticTrue(normalizedValue);

                if (executeAction)
                {
                    actionsToExecute[action.Key] = normalizedValue;
                }
            }

            ExecuteMovementAction(creature, actionsToExecute);
        }

        public void ExecuteMovementAction(List<Creature> creatures)
        {
            foreach (Creature creature in creatures)
            {
                //ExecuteMovementAction(creature);
            }
        }

        public void ExecuteMovementAction(Creature creature, Dictionary<CreatureAction, double> actions)
        {
            // Combine them somehow?
            double moveX = 0;
            double moveY = 0;

            foreach (KeyValuePair<CreatureAction, double> action in actions)
            {
                switch (action.Key)
                {
                    case CreatureAction.MOVE_FORWARD:
                        moveY += action.Value;
                        break;
                    case CreatureAction.MOVE_BACKWARD:
                        moveY -= action.Value;
                        break;
                    case CreatureAction.MOVE_LEFT:
                        moveX -= action.Value;
                        break;
                    case CreatureAction.MOVE_RIGHT:
                        moveX += action.Value;
                        break;
                }
            }

            // Update the X, Y values of the creature DONT FORGET creature.speed
            double finalMoveX = creature.speed * moveX;
            double finalMoveY = creature.speed * moveY;

            // ^^^^^ TODO NEED SOME WAY TO MAKE SURE CREATURE DON'T GO OFF THE MAP HERE
            // ^^^^ TODO NEED TO MAKE SURE CREATURES DON'T COLLIDE WITH EACHOTHER
            // TODO give creatures some initiative score to determine the order in which they move

            // Convert.ToInt32() should round the double value to nearest integer
            creature.creatureXLocation += Convert.ToInt32((finalMoveX));
            creature.creatureYLocation += Convert.ToInt32((finalMoveY));
        }

        private bool ProbabilisticTrue(double factor)
        {
            Debug.Assert(factor <= 1); // Factor must be between 0 and 1

            var rand = new Random(); // TODO move this to a location where it's only initialized once, or once per thread
            var randNum = (rand.NextDouble() * (10 - 1) + 1) / 10;
            var rounded = Math.Round(randNum, 2);

            //Console.WriteLine($"Factor: {factor} - - - Rand Num: {rounded}"); // Log Statement

            return rounded < factor;
        }
    }
}