﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProject
{
    public class Region
    {
        public string name;
        public int unitAvailable;
        public float costPerUnit;
        public Unit Units;
    }

    public class Unit
    {
        public List<ServicePerUnit> Services;
    }

    public class ServicePerUnit
    {
        public string Service;
        public int Quantity;
    }
}
