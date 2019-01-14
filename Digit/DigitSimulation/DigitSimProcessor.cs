using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitSimulation
{
    public class DigitSimProcessor
    {
        private readonly Stopwatch stopwatch = new Stopwatch();
        public TimeSpan LastStepDuration { get; private set; }

        public TimeSpan Step(DigitSim doc)
        {
            stopwatch.Restart();
            //process connections
            Parallel.ForEach(doc.connections, ProcessConnection);
            //process elements
            Parallel.ForEach(doc.elements, ProcessElement);
            stopwatch.Stop();
            return LastStepDuration = stopwatch.Elapsed;
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
