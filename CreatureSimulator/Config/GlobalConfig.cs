namespace CreatureSimulator.Config
{
    public static class GlobalConfig
    {
        // These configs represent an X * Y sized grid
        public static int MapSizeX { get; set; } = 10;
        public static int MapSizeY { get; set; } = 10;

        // Scale value to get from grid size to actual on-screen panel size
        public static int MapSizeScaler { get; set; } = 100;

        // These configs represent controls for creature genome/neurons
        public static int GenomeSize { get; set; } = 5;
        public static int InputNeuronCount { get; set; } = 5;
        public static int InternalNeuronCount { get; set; } = 5;
        public static int OutputNeuronCount { get; set; } = 5;


        // These configs represent controls for creature characteristics
        public static int CreatureRadiusSize { get; set; } = 15;

        #region General Simulation Settings
        public static int GenerationLength { get; set; } = 10;
        public static int SimCycleDelay { get; set; } = 500; // Controls speed of simulation - value is milliseconds
        public static int MaxCreatures { get; set; } = 10; // Maximum creatures on map
        #endregion
    }
}
