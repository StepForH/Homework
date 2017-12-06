using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С2ls2.Workers
{
    public class BasedOnTimeWorker : SimpletWorker
    {
        public BasedOnTimeWorker(int id, string name, double rate) : base(id, name, rate) { }

        public override double Salary
        {
            get { return 20.8 * 8 * rate; }
        }
    }
}
