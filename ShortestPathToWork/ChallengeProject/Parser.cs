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
            ParsedData data = new ParsedData();

            ParseTotalNumbers(data, _arraysToParse[0]);

            for (int j = 0; j < data.Services.Length; j++)
            {
                data.Services[j] = _arraysToParse[1][j]; // servizio
            }

            for (int j = 0; j < data.Countries.Length; j++)
            {
                data.Countries[j] = _arraysToParse[2][j]; // nazione
            }

            int currentProviderLine = 3;
            for (int i = 0; i < data.Providers.Length; i++)
            {
                int regionCount = ParseProviders(data, _arraysToParse, currentProviderLine, i);
                currentProviderLine += (regionCount * 3) + 1;
            }

            int parsedLine = currentProviderLine;
            for (int i = 0; i < data.Projects.Length; i++)
            {
                data.Projects[i] = new Project();
                ParseProjects(data, data.Projects[i], _arraysToParse[parsedLine]);
                parsedLine++;
            }

            return data;
        }

        static void ParseTotalNumbers(ParsedData _data, string[] _lineToParse)
        {
            _data.Services = new string[Int32.Parse(_lineToParse[1])]; // n servizi
            _data.Countries = new string[Int32.Parse(_lineToParse[2])]; // n nazioni

            _data.Providers = new Provider[Int32.Parse(_lineToParse[0])]; // n providers
            _data.Projects = new Project[Int32.Parse(_lineToParse[3])]; // n progetti
        }

        static int ParseProviders(ParsedData _data, string[][] _arraysToParse, int _currentProviderLine, int _currentProviderIndex)
        {
            _data.Providers[_currentProviderIndex] = new Provider();
            _data.Providers[_currentProviderIndex].Name = _arraysToParse[_currentProviderLine][0]; // prover name

            int regionCount = Int32.Parse(_arraysToParse[_currentProviderLine][1]); // numero di regioni

            _data.Providers[_currentProviderIndex].regions = new Region[regionCount];

            // new region
            for (int i = 0; i < regionCount; i++)
            {
                _data.Providers[_currentProviderIndex].regions[i] = new Region();
                ParseRegion(_data, _data.Providers[_currentProviderIndex].regions[i], _arraysToParse, (_currentProviderLine + 1) +  (3 * i));
            }

            _currentProviderIndex++;

            return regionCount;
        }

        static void ParseRegion(ParsedData _data, Region _region, string[][] _arraysToParse, int _startLine)
        {
            _region.Name = _arraysToParse[_startLine][0];

            _region.UnitAvailable = Int32.Parse(_arraysToParse[_startLine + 1][0]);
            _region.CostPerUnit = float.Parse(_arraysToParse[_startLine + 1][1].Replace('.', ','));

            // new unit
            _region.Units = new Unit();
            _region.Units.Services = new ServicePerUnit[_data.Services.Length];
            for (int i = 0; i < _data.Services.Length; i++)
            {
                _region.Units.Services[i] = new ServicePerUnit();
                _region.Units.Services[i].Service = _data.Services[i];
                _region.Units.Services[i].Quantity = Int32.Parse(_arraysToParse[_startLine + 1][i + 2]);
            }

            // new latency
            _region.RegionLatency = new Latency[_data.Countries.Length];
            for (int i = 0; i < _data.Countries.Length; i++)
            {
                _region.RegionLatency[i] = new Latency();
                _region.RegionLatency[i].Country = _data.Countries[i];
                _region.RegionLatency[i].LatencyValue = Int32.Parse(_arraysToParse[_startLine + 2][i]);
            }
        }

        static void ParseProjects(ParsedData _data, Project _project, string[] _lineToParse)
        {
            _project.PenaltyValue = Int32.Parse(_lineToParse[0]);
            _project.Country = _lineToParse[1];

            // new ServicePerUnit
            _project.NeededServices = new ServicePerUnit[_data.Services.Length];
            for (int i = 0; i < _data.Services.Length; i++)
            {
                _project.NeededServices[i] = new ServicePerUnit();
                _project.NeededServices[i].Service = _data.Services[i];
                _project.NeededServices[i].Quantity = Int32.Parse(_lineToParse[i + 2]);
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
