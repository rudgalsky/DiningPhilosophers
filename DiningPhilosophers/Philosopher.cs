using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilosophers
{
    class Philosopher
    {
        private readonly int _x;
        private readonly int _y;

        private readonly Stick _stickA;
        private readonly Stick _stickB;

        private static object _consoleLocker = new object();

        Thread _thread;

        public Philosopher(int x, int y, Stick stickA, Stick stickB)
        {
            _x = x;
            _y = y;

            _stickA = stickA;
            _stickB = stickB;
        }

        public void Initial()
        {
            _thread = new Thread(new ThreadStart(Lunch));
            _thread.Start();
        }

        public void WakeUp()
        {
            PrintPhilosopher("(O_O)");
        }

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

        public void Sleep()
        {
            PrintPhilosopher("(-_-)");

            Random random = new Random();
            Thread.Sleep(random.Next(5000, 10000));
        }

        private void PrintPhilosopher(string philosopherImage)
        {
            Monitor.Enter(_consoleLocker);

            Console.SetCursorPosition(_x, _y);
            Console.Write(philosopherImage);

            Monitor.Exit(_consoleLocker);
        }

        private void Lunch()
        {
            while (true)
            {
                Sleep();
                WakeUp();
                Eat();
            }
        }
    }
}
