﻿using CreatureSimulator.Config;
using CreatureSimulator.Creatures;
using CreatureSimulator.Network;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CreatureSimulator.Simulator
{
    public class Simulation
    {
        private int[,] simulationGrid = new int[GlobalConfig.MapSizeX, GlobalConfig.MapSizeY];
        private int generationLength = GlobalConfig.GenerationLength;
        private readonly SimulatorWindow _window;
        private List<Creature> _creatures;

        #region Constructor
        public Simulation()
        {
            _window = new SimulatorWindow();
            _creatures = new List<Creature>();
        }
        #endregion

        public void Run()
        {
            _window.Show();

            // Initial Paint of creatures on map
            for (int i = 0; i < GlobalConfig.MaxCreatures; i++)
            {
                NeuralNetwork network = new NeuralNetwork();
                network.InitRandomNeuralNetwork(3, 4, 5, 5);

                var creature = new Creature(network);
                _creatures.Add(creature);
                _window.PaintCreature(creature);
            }

            Thread movementThread = new Thread(RunMovement);
            movementThread.IsBackground = true;
            movementThread.Start();

            Application.Run(_window);
        }

        public void RunMovement()
        {
            //Movement Loop
            while (true)
            {
                List<Creature> deadCreatures = new List<Creature>();

                for (int i = 0; i < generationLength; i++) // Each Loop Here Is One Generation
                {
                    _window.ClearPanel();
                    foreach (Creature creature in _creatures)
                    {
                        creature.NeuralNetwork.FeedForward(); // Feed that shizz
                        creature.ExecuteActions(); // Execute that shizznips
                        _window.PaintCreature(creature);

                        if (i == generationLength - 1)
                        {
                            if (_window.IsPointSafe(creature.creatureXLocation, creature.creatureYLocation))
                            {
                                deadCreatures.Add(creature);
                            }
                        }
                    }

                    Thread.Sleep(GlobalConfig.SimCycleDelay); // This adjusts the speed of the simulation
                }

                HandleGenerationChange(deadCreatures);
            }
        }

        #region Remove Dead Creatures From List Of Creatures & And Reproduce New Creatures
        public void HandleGenerationChange(List<Creature> deadCreatures)
        {
            foreach (Creature creature in deadCreatures)
            {
                _creatures.Remove(creature);
            }

            List<Creature> newCreatures = new List<Creature>();

            foreach (Creature creature in _creatures)
            {
                List<Creature> offSpring = creature.Reproduce();
                foreach (Creature offs in offSpring)
                {
                    newCreatures.Add(offs);
                }
            }

            _creatures.Clear();
            _creatures = newCreatures;
        }
        #endregion
    }
}