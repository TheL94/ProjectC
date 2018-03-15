using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProject
{
    public class Parser
    {
        public static ParsedData ParseInputputData(string[][] _arraysToParse)
        {
            int sumOfProversRegions = 0;
            int currentProviderIndex = 0;

            ParsedData data = new ParsedData();
            for (int i = 0; i < _arraysToParse.Length;)
            {
                if(i == 0)
                {
                    data.Services = new string[Int32.Parse(_arraysToParse[i][1])]; // n servizi
                    data.Countries = new string[Int32.Parse(_arraysToParse[i][2])]; // n nazioni

                    data.Providers = new Provider[Int32.Parse(_arraysToParse[i][0])]; // n providers
                    data.Projects = new Project[Int32.Parse(_arraysToParse[i][3])]; // n progetti
                    i++;
                    continue;
                }
                else if(i == 1)
                {
                    for (int j = 0; j < data.Services.Length; j++)
                    {
                        data.Services[j] = _arraysToParse[i][j]; // servizio
                    }
                    i++;
                    continue;
                }
                else if (i == 2)
                {
                    for (int j = 0; j < data.Countries.Length; j++)
                    {
                        data.Countries[j] = _arraysToParse[i][j]; // nazione
                    }
                    i++;
                    continue;
                }
                else if(i > 2 && i < sumOfProversRegions)
                {
                    data.Providers[currentProviderIndex] = new Provider();
                    data.Providers[currentProviderIndex].Name =_arraysToParse[i][0]; // prover name

                    int regionCount = Int32.Parse(_arraysToParse[i][1]); // numero di regioni

                    data.Providers[currentProviderIndex].regions = new Region[regionCount];

                    sumOfProversRegions += regionCount;

                    // new region
                    for (int j = 0; j < regionCount; j++)
                    {
                        data.Providers[currentProviderIndex].regions[j].name = _arraysToParse[i + 1][0];

                        data.Providers[currentProviderIndex].regions[j].UnitAvailable = Int32.Parse(_arraysToParse[i + 2][0]);
                        data.Providers[currentProviderIndex].regions[j].CostPerUnit = float.Parse(_arraysToParse[i + 2][1]);

                        // new unit
                        data.Providers[currentProviderIndex].regions[j].Units = new Unit();
                        for (int k = 2; k < data.Services.Length; k++)
                        {
                            data.Providers[currentProviderIndex].regions[j].Units.Services[k - 2].Service = data.Services[k - 2];
                            data.Providers[currentProviderIndex].regions[j].Units.Services[k - 2].Quantity = Int32.Parse(_arraysToParse[i + 2][k]);
                        }

                        // new latency
                        data.Providers[currentProviderIndex].regions[j].RegionLatency = new Latency[data.Countries.Length];
                        for (int k = 0; k < data.Countries.Length; k++)
                        {
                            data.Providers[currentProviderIndex].regions[j].RegionLatency[k].Country = data.Countries[k];
                            data.Providers[currentProviderIndex].regions[j].RegionLatency[k].LatencyValue = Int32.Parse(_arraysToParse[i + 3][k]);
                        }
                    }

                    currentProviderIndex++;

                    i += regionCount * 3;
                    continue;
                }
                else
                {

                }
            }

            return data;
        }

        public static string[][] ParseOutputData()
        {
            return null;
        }
    }

    public class ParsedData
    {
        public string[] Services;
        public string[] Countries;

        public Provider[] Providers;
        public Project[] Projects;
    }
}
