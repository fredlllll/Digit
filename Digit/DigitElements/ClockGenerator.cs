using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitSimulation;

namespace DigitElements
{
    class ClockGenerator : SimElement
    {
        public int ticksLow = 200;
        public int ticksHigh = 200;

        int count = 0;

        public ClockGenerator(DigitSim doc) : base(doc)
        {
            outputs = new SimElementOutput[] { new SimElementOutput(this) };
        }

        public override void Tick()
        {
            bool result = false;

            count++;
            if(count > ticksLow)
            {
                result = true;
                if( count >= ticksLow + ticksHigh)
                {
                    count = 0;
                }
            }

            outputs[0].value = result;
        }
    }
}
