using EnvironmentSystem.Interfaces;
using EnvironmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Core
{
    public class ModifiedEngine : Engine
    {
        private KeyboardController controller;
        public static bool isPaused = false;

        public ModifiedEngine(KeyboardController controller)
            : base()
        {
            this.controller = controller;
        }

        protected override void ExecuteEnvironmentLoop()
        {
            this.controller.InvokeEvent();

            if (ModifiedEngine.isPaused)
            {
                return;
            }

            base.ExecuteEnvironmentLoop();
        }

        protected override void Insert(EnvironmentObject obj)
        {
            if (obj != null)
            {
                base.Insert(obj);   
            }
        }
    }
}
