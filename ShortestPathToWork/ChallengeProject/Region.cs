using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProject
{
    public class Region
    {
        public string Name;
        public int UnitAvailable;
        public float CostPerUnit;
        public Unit Units;
        public Latency[] RegionLatency;
    }

    public class Unit
    {
        public ServicePerUnit[] Services;
    }

    public class ServicePerUnit
    {
        public string Service;
        public int Quantity;
    }

    public class Latency
    {
        public string Country;
        public int LatencyValue;
    }
}
