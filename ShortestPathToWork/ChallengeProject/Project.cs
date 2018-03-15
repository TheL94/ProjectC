using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProject
{
    public class Project
    {
        public int Penalty;
        public string Country;
        public List<ServicePerUnit> NeededServices = new List<ServicePerUnit>();
    }
}
