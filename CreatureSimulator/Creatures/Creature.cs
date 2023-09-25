using CreatureSimulator.Network;

namespace CreatureSimulator.Creatures
{
    public class Creature
    {
        private ActionHandler actionHandler;

        // Personal Information
        public int Age { get; set; }
        public bool Gender { get; set; } = false; // True for male, false for female

        // Neural Network Information
        public Genome Genome { get; set; } = new Genome();
        public NeuralNetwork NeuralNetwork { get; set; }
        public decimal OscillatorPeriod { get; set; } // TODO not sure what I want to do here yet

        // Creatures X,Y location corresponding to on screen X,Y
        public int creatureXLocation { get; set; }
        public int creatureYLocation { get; set; }

        // Speed of N cells per simulation cycle
        public int speed = 20;

        public Creature(NeuralNetwork neuralNetwork)
        {
            NeuralNetwork = neuralNetwork;
            actionHandler = new ActionHandler();

            // TODO FOR NOW INITIALIZING RANDOM VALUES - IN FUTURE HAVE PRESETS N SUCH
            InitializeRandomCreature(neuralNetwork);
        }

        // Shortcut Function to initialize a creature with random attributes
        public Creature InitializeRandomCreature(NeuralNetwork network)
        {
            Random rand = new Random();

            this.NeuralNetwork = network;
            this.Age = rand.Next(1, 100);

            var genderSeed = rand.Next(0, 2);
            if (genderSeed == 0)
            {
                this.Gender = true;
            }
            else
            {
                this.Gender = false;
            }

            this.creatureXLocation = rand.Next(1, 1000);
            this.creatureYLocation = rand.Next(1, 1000);

            return this;
        }

        #region Function To Execute Actions
        public void ExecuteActions()
        {
            actionHandler.ExecuteActions(NeuralNetwork.MapNeuronsToActions(), this);
        }
        #endregion

        #region Function To Reproduce And Pass Network To New Creature(s)
        public List<Creature> Reproduce()
        {
            var creatures = new List<Creature>();

            Random rand = new Random();
            int offSpring = rand.Next(1, 3);
            
            for (int i = 0; i <= offSpring; i++)
            {
                var creature = new Creature(this.NeuralNetwork).InitializeRandomCreature(this.NeuralNetwork);
                creatures.Add(creature);
            }

            return creatures;
        }
        #endregion
    }
}
