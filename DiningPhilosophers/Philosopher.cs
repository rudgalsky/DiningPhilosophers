using System;
using System.Threading;

namespace DiningPhilosophers
{
    /// <summary>
    /// Represents a philosopher.
    /// </summary>
    class Philosopher
    {
        /// <summary>
        /// X coordinate for console.
        /// </summary>
        private readonly int _x;

        /// <summary>
        /// Y coordinate for console.
        /// </summary>
        private readonly int _y;

        /// <summary>
        /// X coordinate for console.
        /// </summary>
        private readonly Stick _stickA;

        /// <summary>
        /// Neighboring stick with the greatest number.
        /// </summary>
        private readonly Stick _stickB;

        /// <summary>
        /// Locker for the cursor position.
        /// </summary>
        private static object _consoleLocker = new object();

        /// <summary>
        /// Thread for actions of lunch.
        /// </summary>
        Thread _lunchThread;

        /// <summary>
        /// Represents a philosopher.
        /// </summary>
        /// <param name="x">X coordinate for console.</param>
        /// <param name="y">Y coordinate for console.</param>
        /// <param name="stickA">X coordinate for console.</param>
        /// <param name="stickB">Neighboring stick with the greatest number.</param>
        public Philosopher(int x, int y, Stick stickA, Stick stickB)
        {
            _x = x;
            _y = y;

            _stickA = stickA;
            _stickB = stickB;
        }

        /// <summary>
        /// Animate the philosopher.
        /// </summary>
        public void Initial()
        {
            _lunchThread = new Thread(new ThreadStart(Lunch));
            _lunchThread.Start();
        }

        /// <summary>
        /// Actions for waking up.
        /// </summary>
        public void WakeUp()
        {
            PrintPhilosopher("(O_O)");
        }

        /// <summary>
        /// Actions for eating.
        /// </summary>
        public void Eat()
        {
            _stickA.Get();
            _stickB.Get();

            PrintPhilosopher("(-o-)");

            Random random = new Random();
            Thread.Sleep(random.Next(3000, 8000));

            _stickB.PutAside();
            _stickA.PutAside();
        }

        /// <summary>
        /// Actions for thinking.
        /// </summary>
        public void Think()
        {
            PrintPhilosopher("(-_-)");

            Random random = new Random();
            Thread.Sleep(random.Next(5000, 10000));
        }

        /// <summary>
        /// Print the philosopher on the console.
        /// </summary>
        /// <param name="philosopherImage">Philosopher's image.</param>
        private void PrintPhilosopher(string philosopherImage)
        {
            Monitor.Enter(_consoleLocker);

            Console.SetCursorPosition(_x, _y);
            Console.Write(philosopherImage);

            Monitor.Exit(_consoleLocker);
        }

        /// <summary>
        /// A cycle thinking, waking up, eating.
        /// </summary>
        private void Lunch()
        {
            while (true)
            {
                Think();
                WakeUp();
                Eat();
            }
        }
    }
}
