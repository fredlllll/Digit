using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitSimulation
{
    public abstract class SimElement
    {
        public readonly DigitSim doc;

        protected SimElementInput[] inputs;
        public SimElementInput[] Inputs { get { return inputs; } }
        protected SimElementOutput[] outputs;
        public SimElementOutput[] Outputs { get { return outputs; } }

        public SimElement(DigitSim doc)
        {
            this.doc = doc;
        }

        public abstract void Tick();
    }
}
