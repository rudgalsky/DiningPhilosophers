using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilosophers
{
    class Stick
    {
        private readonly int _x;
        private readonly int _y;

        private char _image;

        private object _locker = new object();

        public Stick(int x, int y, char image)
        {
            _x = x;
            _y = y;

            _image = image;
        }

        public void Initial()
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(_image);
        }

        public void Get()
        {
            Monitor.Enter(_locker);
        }

        public void PutAside()
        {
            Monitor.Exit(_locker);
        }
    }
}
