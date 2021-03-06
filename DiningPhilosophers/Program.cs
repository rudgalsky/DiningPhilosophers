using System;
using System.Collections.Generic;

namespace DiningPhilosophers
{
    /// <summary>
    /// Main class
    /// </summary>
    class Program
    {
        /// <summary>
        /// List of philosophers.
        /// </summary>
        private static List<Philosopher> _philosophers;

        /// <summary>
        /// List of sticks.
        /// </summary>
        private static List<Stick> _sticks;

        /// <summary>
        /// Start entry point.
        /// </summary>
        /// <param name="args">Arguments.</param>
        static void Main(string[] args)
        {
            _sticks = new List<Stick>
            {
                new Stick(11, 3, '/'),
                new Stick(11, 5, '-'),
                new Stick(9, 6, '|'),
                new Stick(7, 5, '-'),
                new Stick(7, 3, '\\')
            };
            _sticks.ForEach(stick => stick.Initial());

            _philosophers = new List<Philosopher>
            {
                new Philosopher(7, 2, _sticks[0], _sticks[4]),
                new Philosopher(11, 4, _sticks[0], _sticks[1]),
                new Philosopher(10, 6, _sticks[1], _sticks[2]),
                new Philosopher(4, 6, _sticks[2], _sticks[3]),
                new Philosopher(3, 4, _sticks[3], _sticks[4])
            };

            foreach (var philosopher in _philosophers)
            {
                philosopher.Initial();
            }

            Console.ReadKey();
        }
    }
}
