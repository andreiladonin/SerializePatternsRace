using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializePatternsRace
{
    public class RaceSerialize
    {
        private readonly string filepath;
        private readonly ISerialize<List<Race>> serialize;
        private readonly string pathsave;

        public RaceSerialize(string filepath, string pathsave, ISerialize<List<Race>> serialize)
        {
            this.filepath = filepath;
            this.serialize = serialize;
            this.pathsave = pathsave;
        }

        private async Task<List<Race>> GetRaces()
        {
            using (StreamReader reader = new StreamReader(filepath))
            {
                var races = new List<Race>();
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (line.Contains('|'))
                    {
                        continue;
                    } 
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        
                        var _ = line.Split(',');
                        int id = int.Parse(_[0].Trim());
                        var fullName = _[1].Trim();
                        var country = _[2].Trim();
                        double points = double.Parse(_[3].Trim());
                        var typeRace = _[4].Trim().TrimEnd(';');



                        var race = new Race() { 
                            Id = id,
                            Player = new Player() { FullName = fullName, Country = country},
                            TypeRace = typeRace,
                            Points = points,
                        };

                        races.Add(race);
                    }

                }

                return races;
            }
        }

        public async Task Serialize()
        {
            var lst = await GetRaces();
            serialize.Serialize(pathsave, lst);
            Console.WriteLine("Ok");
        }
    }
}
