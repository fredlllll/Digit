using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitSimulation
{
    public class SimElementOutput
    {
        public readonly SimElement element;
        public readonly List<SimConnection> connections = new List<SimConnection>(); //outputs can have multiple connections

        public bool value;

        public SimElementOutput(SimElement element)
        {
            this.element = element;
        }
    }
}
