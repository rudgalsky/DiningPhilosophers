using System;
using System.Threading;

namespace DiningPhilosophers
{
    /// <summary>
    /// Represents a stick.
    /// </summary>
    class Stick
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
        /// Image for console.
        /// </summary>
        private char _image;

        /// <summary>
        /// Stick locker for philosophers.
        /// </summary>
        private object _locker = new object();

        /// <summary>
        /// Represents a stick.
        /// </summary>
        /// <param name="x">X coordinate for console.</param>
        /// <param name="y">Y coordinate for console.</param>
        /// <param name="image">Stick locker for philosophers.</param>
        public Stick(int x, int y, char image)
        {
            _x = x;
            _y = y;

            _image = image;
        }

        /// <summary>
        /// Writes the stick.
        /// </summary>
        public void Initial()
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(_image);
        }

        /// <summary>
        /// Pick up the stick.
        /// </summary>
        public void Get()
        {
            Monitor.Enter(_locker);
        }

        /// <summary>
        /// Put aside the stick
        /// </summary>
        public void PutAside()
        {
            Monitor.Exit(_locker);
        }
    }
}
