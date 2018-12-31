using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitSimulation
{
    public class DigitSimProcessor
    {
        private readonly DigitSim doc;

        public DigitSimProcessor(DigitSim doc)
        {
            this.doc = doc;
        }

        public void Step(DigitSim doc)
        {
            //process connections
            Parallel.ForEach(doc.connections, ProcessConnection);
            //process elements
            Parallel.ForEach(doc.elements, ProcessElement);
        }

        void ProcessConnection(SimConnection c)
        {
            c.Tick();
        }

        void ProcessElement(SimElement e)
        {
            e.Tick();
        }
    }
}
