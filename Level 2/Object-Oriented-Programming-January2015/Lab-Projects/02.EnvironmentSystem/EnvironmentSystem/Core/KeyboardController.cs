using EnvironmentSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnvironmentSystem.Core
{
    public class KeyboardController : IController
    {
        public event EventHandler Pause;

        public KeyboardController()
        {
            this.Pause = (obj, args) =>
            {
                this.ProcessInput();
            };
        }

        public void ProcessInput()
        {
             if (Console.KeyAvailable)
            {

                ConsoleKeyInfo userInput = Console.ReadKey();
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (userInput.Key == ConsoleKey.Spacebar)
                {
                    ModifiedEngine.isPaused = !ModifiedEngine.isPaused;
                }
            }
        }

        public void InvokeEvent() 
        {
            this.Pause(this, new EventArgs());
        }
    }
}
