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
                    ParseTotalNumbers(data, _arraysToParse[i]);
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
                else if(i < sumOfProversRegions)
                {
                    ParseProviders(data, _arraysToParse, i, currentProviderIndex);
                    
                    continue;
                }
                else
                {

                }
            }

            return data;
        }

        static void ParseTotalNumbers(ParsedData _data, string[] _line)
        {
            _data.Services = new string[Int32.Parse(_line[1])]; // n servizi
            _data.Countries = new string[Int32.Parse(_line[2])]; // n nazioni

            _data.Providers = new Provider[Int32.Parse(_line[0])]; // n providers
            _data.Projects = new Project[Int32.Parse(_line[3])]; // n progetti
        }

        static void ParseProviders(ParsedData _data, string[][] _arraysToParse, int _i, int _currentProviderIndex)
        {
            _data.Providers[_currentProviderIndex] = new Provider();
            _data.Providers[_currentProviderIndex].Name = _arraysToParse[_i][0]; // prover name

            int regionCount = Int32.Parse(_arraysToParse[_i][1]); // numero di regioni

            _data.Providers[_currentProviderIndex].regions = new Region[regionCount];

            // new region
            for (int i = 0; i < regionCount; i++)
            {
                ParseRegion(_data, _data.Providers[_currentProviderIndex].regions[i], _arraysToParse, (_i + 1) +  (3 * i));
            }

            _currentProviderIndex++;
        }

        static void ParseRegion(ParsedData _data, Region _region, string[][] _arraysToParse, int _startLine)
        {
            _region.name = _arraysToParse[_startLine][0]; // s

            _region.UnitAvailable = Int32.Parse(_arraysToParse[_startLine + 1][0]);
            _region.CostPerUnit = float.Parse(_arraysToParse[_startLine + 1][1]);

            // new unit
            _region.Units = new Unit();
            for (int i = 2; i < _data.Services.Length; i++)
            {
                _region.Units.Services[i - 2].Service = _data.Services[i - 1];
                _region.Units.Services[i - 2].Quantity = Int32.Parse(_arraysToParse[_startLine + 1][i]);
            }

            // new latency
            _region.RegionLatency = new Latency[_data.Countries.Length];
            for (int i = 0; i < _data.Countries.Length; i++)
            {
                _region.RegionLatency[i].Country = _data.Countries[i];
                _region.RegionLatency[i].LatencyValue = Int32.Parse(_arraysToParse[_startLine + 2][i]);
            }
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
