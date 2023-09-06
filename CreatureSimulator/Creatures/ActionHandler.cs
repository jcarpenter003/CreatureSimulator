using CreatureSimulator.Enum;

namespace CreatureSimulator.Creatures
{
    public class ActionHandler
    {
        /*
         * Parameters: The List of action neurons (need to also take an associated double for each action to see how driven it is) && the creature for which these actions are occuring
         * Maybe we can get the list of action neurons and how driven they are from the Creatures NeuralNetwork property
         * 
         */
        public void ExecuteAction(List<CreatureAction> actions, Creature creature)
        {
            foreach (CreatureAction action in actions)
            {
                switch (action)
                {
                    case CreatureAction.MOVE_FORWARD:
                        Console.WriteLine("Move Forward Triggerd");
                        break;
                    case CreatureAction.MOVE_BACKWARD:
                        Console.WriteLine("Move Backward Triggerd");
                        break;
                    case CreatureAction.MOVE_RIGHT:
                        Console.WriteLine("Move Right Triggerd");
                        break;
                    case CreatureAction.MOVE_LEFT:
                        Console.WriteLine("Move Left Triggerd");
                        break;
                }
            }
        }
    }
}
