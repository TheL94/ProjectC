using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProject
{
    public static class Evaluator
    {
        public static List<EvaluatedData> EvaluateProject(Project _project, int _maxCost, int _minCost, ParsedData _data)
        {
            List<EvaluatedData> returnData = new List<EvaluatedData>();
            float actualK = (float)Math.Pow(_project.PenaltyValue / _minCost, _minCost / _maxCost);

            ServicePerUnit[] allocated;

            foreach (EvaluatedData item in returnData)
            {
                item.Units
            }
        }

        static EvaluatedData SerchBestUnit(ServicePerUnit[] _allocated, ServicePerUnit[] _needed, ParsedData _data, float _actualK, Project project)
        {
            EvaluatedData returnData = new EvaluatedData();
            ServicePerUnit[] actualBestAllocation = new ServicePerUnit[_data.Services.Length];
            float param = -1;

            foreach (var provider in _data.Providers)
            {
                foreach (var region in provider.regions)
                {
                    for (int i = 0; i < region.Units.Services.Length; i++)
                    {
                        actualBestAllocation[i].Quantity = _allocated[i].Quantity + region.Units.Services[i].Quantity;

                    }

                    float dinstance = 0;

                    for (int i = 0; i < region.Units.Services.Length; i++)
                    {
                        dinstance += (float)Math.Pow((_needed[i].Quantity - actualBestAllocation[i].Quantity), 2);
                    }
                    if(param == -1)
                    {
                        param = dinstance * (float)Math.Pow(region.CostPerUnit, _actualK) * region.RegionLatency[Parser.ReturnCountryIndexByName(_data, project.Country)].LatencyValue;
                    }
                    else
                    {
                        if(param < dinstance * (float)Math.Pow(region.CostPerUnit, _actualK) * region.RegionLatency[Parser.ReturnCountryIndexByName(_data, project.Country)].LatencyValue)
                        {
                            param = dinstance * (float)Math.Pow(region.CostPerUnit, _actualK) * region.RegionLatency[Parser.ReturnCountryIndexByName(_data, project.Country)].LatencyValue;
                        }
                        else
                        {
                            actualBestAllocation = new ServicePerUnit[_data.Services.Length];
                            returnData.ProviderName = provider.Name;
                            returnData.RegionName = region.Name;
                        }
                    }
                }
            }
            return returnData;
        }

    }

    public class EvaluatedData
    {
        public string ProviderName;
        public string RegionName;
        public int Units;
    }
}
