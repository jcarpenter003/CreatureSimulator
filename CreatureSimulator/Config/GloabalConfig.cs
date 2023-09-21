namespace CreatureSimulator.Config
{
    public static class GloabalConfig
    {
        // These configs represent an X * Y sized grid
        public static int MapSizeX { get; set; } = 10;
        public static int MapSizeY { get; set; } = 10;

        // Scale value to get from grid size to actual on-screen panel size
        public static int MapSizeScaler { get; set; } = 100;

        // These configs represent controls for creatures genome/neurons
        public static int GenomeSize { get; set; } = 5;
        public static int InputNeuronCount { get; set; } = 5;
        public static int InternalNeuronCount { get; set; } = 5;
        public static int OutputNeuronCount { get; set; } = 5;
    }
}
