using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitSimulation
{
    public class SimElementInput
    {
        public readonly SimElement element;
        public bool value;
        public SimConnection connection;

        public SimElementInput(SimElement element)
        {
            this.element = element;
        }
    }
}
