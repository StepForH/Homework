using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С2ls2.Workers
{
    public abstract class SimpletWorker
    {
        
       protected double rate;
       public int Id { get; set; }
       public string Name { get; set; }

       public abstract double Salary { get; }

       public SimpletWorker(int id, string name, double rate)
       {
        Id = id;
        Name = name;
        this.rate = rate;
       }
    }
}