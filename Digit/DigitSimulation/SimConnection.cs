using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitSimulation
{
    public class SimConnection
    {
        public SimElementOutput output;
        public SimElementInput input;

        public void Tick()
        {
            //move value from output to input
            input.value = output.value;
        }
    }
}
